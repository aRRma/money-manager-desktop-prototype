using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MoneyManager.Core.RegistrationServices.AutoRegister.Config;
using MoneyManager.Core.RegistrationServices.AutoRegister.Interfaces;
using MoneyManager.Core.Utils;
using System.Reflection;

namespace MoneyManager.Core.RegistrationServices.AutoRegister
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Зарегистрировать конкретную реализацию авто рег. сервиса
        /// </summary>
        /// <param name="provider">Провайдер сервисов</param>
        public static IServiceCollection RegisterAutoServices(this IServiceCollection provider)
        {
            AutoRegisterServicesConfig config = provider
                .BuildServiceProvider()
                .GetRequiredService<IOptions<AutoRegisterServicesConfig>>()
                .Value;

            if (!config?.ServicesInfo?.Any() ?? true)
                return provider;

            foreach (var serviceInfo in config!.ServicesInfo!)
            {
                try
                {
                    if (!string.IsNullOrEmpty(serviceInfo.AssemblyName))
                        provider.ProcessRegistrationServiceFromAssembly(serviceInfo);
                    else
                        provider.ProcessRegistrationService(serviceInfo);
                }
                catch (Exception ex) // TODO спец эксепшен замутить
                {
                    // TODO log и толи падать толи продолжать
                    throw;
                }
            }

            return provider;
        }

        /// <summary>
        /// Возвращает сервис наследник <see cref="IAutoRegisterService"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="provider">Провайдер сервисов</param>
        /// <returns></returns>
        public static T? GetAutoService<T>(this IServiceCollection provider)
            where T : class, IAutoRegisterService, new()
        {
            return provider
                .BuildServiceProvider()
                .GetServices<IAutoRegisterService>()
                .SingleOrDefault(x => Type.Equals(x.GetType(), typeof(T))) as T;
        }

        /// <summary>
        /// Возвращает обязательно сервис наследник <see cref="IAutoRegisterService"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="provider">Провайдер сервисов</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static T GetRequiredAutoService<T>(this IServiceCollection provider)
            where T : class, IAutoRegisterService, new()
        {
            var service = GetAutoService<T>(provider);

            if (service is null)
                throw new InvalidOperationException($"Service by type [{typeof(T).Name}] not exist");

            return service;
        }

        /// <summary>
        /// Зарегестрировать сервис в DI
        /// </summary>
        /// <param name="provider">Провайдер сервисов</param>
        /// <param name="type">Тип сервиса</param>
        /// <param name="injectionType">Тип регистрации в DI</param>
        /// <returns></returns>
        public static IServiceCollection AddServiceByRule(this IServiceCollection provider, Type type, ServiceInjectionType injectionType)
        {
            switch (injectionType)
            {
                case ServiceInjectionType.Singleton:
                    provider.AddSingleton(typeof(IAutoRegisterService), type);
                    break;
                case ServiceInjectionType.Transient:
                    provider.AddTransient(typeof(IAutoRegisterService), type);
                    break;
                case ServiceInjectionType.Scoped:
                    provider.AddScoped(typeof(IAutoRegisterService), type);
                    break;
            }

            return provider;
        }

        private static void ProcessRegistrationService(this IServiceCollection provider, AutoRegisterServiceInfo serviceInfo)
        {
            var assemblies = ReflectionUtils.GetAllAssembliesByType(typeof(IAutoRegisterService));
            var type = ReflectionUtils.GetTypeByName(assemblies, serviceInfo.Name);

            if (type is null)
            {
                // TODO падаем и логируем
                throw new ArgumentNullException($"Not find type implement to service {serviceInfo.Name}");
            }

            InvokeRegisterMethod(provider, type, serviceInfo);
        }

        private static void ProcessRegistrationServiceFromAssembly(this IServiceCollection provider, AutoRegisterServiceInfo serviceInfo)
        {
            var assembly = Assembly.Load(serviceInfo.AssemblyName!);
            var type = assembly.GetTypes()
                    .SingleOrDefault(x => string.Equals(x.Name, serviceInfo.Name, StringComparison.CurrentCultureIgnoreCase));

            if (type is null)
            {
                // TODO падаем и логируем
                throw new ArgumentNullException($"Not find type implement to service {serviceInfo.Name}");
            }

            InvokeRegisterMethod(provider, type, serviceInfo);
        }

        private static void InvokeRegisterMethod(IServiceCollection provider, Type type, AutoRegisterServiceInfo serviceInfo)
        {
            object instance = type.GetConstructor(Type.EmptyTypes)!.Invoke(new object[] { });
            var regMethod = type.GetMethod(nameof(IAutoRegisterService.AutoRegister), BindingFlags.Public | BindingFlags.Instance);
            regMethod?.Invoke(instance, new object[] { provider, type, serviceInfo });
        }
    }
}
