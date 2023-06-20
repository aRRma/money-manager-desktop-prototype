using System.Reflection;

namespace MoneyManager.Core.Utils
{
    public static class ReflectionUtils
    {
        public static List<Assembly> GetAllAssembliesByType(Type type)
       {
            var types1 = Assembly.GetExecutingAssembly().GetTypes();
            var types2 = Assembly.GetCallingAssembly().GetTypes();

            var allTypes = types1.Union(types2);

            var service = allTypes.Where(x => type.IsAssignableFrom(x)).ToList();

            return null;
        }
    }
}
