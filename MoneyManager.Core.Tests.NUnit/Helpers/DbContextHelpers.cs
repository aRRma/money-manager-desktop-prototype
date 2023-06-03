using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Tests.NUnit.Constants;
using System.Runtime.CompilerServices;

namespace MoneyManager.Core.Tests.NUnit.Helpers
{
    internal static class DbContextHelpers
    {
        public static DbContextOptions<T> GetDataBaseOptions<T>(out string dbName, [CallerMemberName] string name = default)
            where T : DbContext
        {
            dbName = $"{name}.{DatabaseConstants.DEFAULT_TESTDB_EXTENSION}";
            var optBuilder = new DbContextOptionsBuilder<T>().UseSqlite($"Data Source = {dbName}");
            return optBuilder.Options;
        }

        public static void DeleteAllDbWithTestExtension()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var files = Directory.GetFiles(path, $"*.{DatabaseConstants.DEFAULT_TESTDB_EXTENSION}");

            foreach (var item in files)
            {
                File.Delete(item);
            }
        }
    }
}
