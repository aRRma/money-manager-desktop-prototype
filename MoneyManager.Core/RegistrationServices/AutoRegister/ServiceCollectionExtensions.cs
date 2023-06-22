using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MoneyManager.Core.RegistrationServices.AutoRegister.Interfaces;
using MoneyManager.Core.RegistrationServices.AutoRegister.Options;
using MoneyManager.Core.Utils;
using System.Reflection;

namespace MoneyManager.Core.RegistrationServices.AutoRegister
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Зарегистрировать конкретную реализацию авто рег. сервиса
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection RegisterAutoServices(this IServiceCollection services)
        {
            AutoRegisterServicesConfig config = services
                .BuildServiceProvider()
                .GetRequiredService<IOptions<AutoRegisterServicesConfig>>()
                .Value;

            if (!config?.ServicesInfo?.Any() ?? true)
                return services;


            foreach (var serviceInfo in config!.ServicesInfo!)
            {
                try
                {
                    if (!string.IsNullOrEmpty(serviceInfo.AssemblyName))
                        services.ProcessRegistrationServiceFromAssembly(serviceInfo);
                    else
                        services.ProcessRegistrationService(serviceInfo);
                }
                catch (Exception ex) // TODO спец эксепшен замутить
                {
                    // TODO log и толи падать толи продолжать
                    throw;
                }
            }

            return services;
        }

        private static void ProcessRegistrationService(this IServiceCollection services, AutoRegisterServiceInfo serviceInfo)
        {
            var assemblies = ReflectionUtils.GetAllAssembliesByType(typeof(IAutoRegisterService));
            var type = ReflectionUtils.GetTypeByName(assemblies, serviceInfo.ImplementationName);

            if (type is null)
            {
                // TODO падаем и логируем
                throw new ArgumentNullException($"Not find type implement to service {serviceInfo.ImplementationName}");
            }

            InvokeRegisterMethod(services, type, serviceInfo);
        }

        private static void ProcessRegistrationServiceFromAssembly(this IServiceCollection services, AutoRegisterServiceInfo serviceInfo)
        {
            var assembly = Assembly.Load(serviceInfo.AssemblyName!);
            var type = assembly.GetTypes()
                    .SingleOrDefault(x => string.Equals(x.Name, serviceInfo.ImplementationName, StringComparison.CurrentCultureIgnoreCase));

            if (type is null)
            {
                // TODO падаем и логируем
                throw new ArgumentNullException($"Not find type implement to service {serviceInfo.ImplementationName}");
            }

            InvokeRegisterMethod(services, type, serviceInfo);
        }

        private static void InvokeRegisterMethod(IServiceCollection services, Type type, AutoRegisterServiceInfo serviceInfo)
        {
            object instance = type
                            .GetConstructor(Type.EmptyTypes)!.Invoke(new object[] { });
            var regMethod = type
                .GetMethod(nameof(IAutoRegisterService.AutoRegister), BindingFlags.Public | BindingFlags.Instance);
            regMethod?.Invoke(instance, new object[] { services, type, serviceInfo });
        }
    }
}
