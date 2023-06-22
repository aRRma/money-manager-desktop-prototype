using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MoneyManager.Core.Models;
using MoneyManager.Core.Utils;

namespace MoneyManager.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Зарегестрировать конкретную реализацию авто рег. сервиса
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        public static void RegisterAutoServiceByName(this IServiceCollection services, IOptions<AutoRegisterServicesOptions> options)
        {
            if (!options.Value.ServicesInfo?.Any() ?? true)
                return;

            var allAutoRegAssemblies = ReflectionUtils.GetAllAssembliesByType(typeof(IAutoRegisterService));

            foreach (var item in options.Value.ServicesInfo!)
            {
                var typeName = GetAutoRegTypeName(item.FullQualifiedServiceName);

                try
                {
                    if (!string.IsNullOrEmpty(item.AssemblyName))
                        ProcessRegistrationServiceFromAssembly(allAutoRegAssemblies, typeName, item.AssemblyName);
                    else
                        ProcessRegistrationService(allAutoRegAssemblies, typeName);
                }
                catch (Exception) // TODO спец эксепшен замутить
                {
                    // TODO log и толи падать толи продолжать
                    throw;
                }
            }
        }

        /// <summary>
        /// Зарегестрировать все авто рег. сервисы по типу
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        public static void RegisterAutoServiceByType(this IServiceCollection services, IOptions<AutoRegisterServicesOptions> options)
        {

        }

        private static void PreProcess()
        {

        }

        private static void ProcessRegistrationService(List<Type> types, string typeName)
        {

        }

        private static void ProcessRegistrationServiceFromAssembly(List<Type> types, string typeName, string assemblyName)
        {

        }

        private static string GetAutoRegTypeName(string fullQualifiedTypeName)
        {
            return fullQualifiedTypeName
                .Split('.', StringSplitOptions.RemoveEmptyEntries)[^1];

        }
    }
}
