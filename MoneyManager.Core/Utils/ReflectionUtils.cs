using System.Reflection;

namespace MoneyManager.Core.Utils
{
    public static class ReflectionUtils
    {
        private static List<Type>? _allAssemblies;
        public static List<Type> AllAssemblies
        {
            get
            {
                // считаем, что однократно подгрузим все сборки и норм
                if (_allAssemblies is not null)
                    return _allAssemblies;

                _allAssemblies = GetAllCurrentAssemblyTypes();
                return AllAssemblies;
            }
        }

        public static List<Type> GetAllAssembliesByType(Type type)
        {
            return AllAssemblies
                .Where(x => type.IsAssignableFrom(x))
                .ToList();
        }

        public static Type? GetTypeByName(List<Type> types, string typeName)
        {
            return types.SingleOrDefault(x => string.Equals(x.Name, typeName, StringComparison.CurrentCultureIgnoreCase));
        }

        private static List<Type> GetAllCurrentAssemblyTypes()
        {
            var executingAssemblyTypes = Assembly.GetExecutingAssembly().GetTypes();
            var callingAssemblyTypes = Assembly.GetCallingAssembly().GetTypes();

            return executingAssemblyTypes
                .Union(callingAssemblyTypes)
                .ToList();
        }
    }
}
