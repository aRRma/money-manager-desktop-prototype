using Allure.Net.Commons;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.DataBase;
using MoneyManager.Core.Tests.NUnit.Constants;
using NUnit.Allure.Core;
using System.Runtime.CompilerServices;

namespace MoneyManager.Core.Tests.NUnit.Helpers
{
    internal static class DbContextTestHelpers
    {
        public static DbContextOptions<AppDbContext> GetDataBaseOptions(out string dbName, [CallerMemberName] string name = default)
        {
            dbName = $"{name}.{DatabaseConstants.DEFAULT_TESTDB_EXTENSION}";
            var optBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite($"Data Source = {dbName}");
            // TODO надо бы конфигурировать
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            //.UseNpgsql($"Host=localhost;Port=5432;Database={dbName};Username=arrma;Password=aRRma151!");
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

        public static AppDbContext CreateAppDbContext([CallerMemberName] string name = default)
        {
            return AllureLifecycle.Instance.WrapInStep(() =>
            {
                var options = GetDataBaseOptions(out var dbName, name);
                var dbContext = new AppDbContext(options, true);
                Console.WriteLine($"Create base [{dbName}]");
                return dbContext;
            }, "Создание контекста и базы данных");
        }

        public static string GetDbNameFromDbContext(AppDbContext context)
        {
            var dbFullName = context.Database
                .GetDbConnection().ConnectionString
                .Split('=', StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim();
            return dbFullName;
            //return Path.GetFileNameWithoutExtension(dbFullName);
        }
    }
}
