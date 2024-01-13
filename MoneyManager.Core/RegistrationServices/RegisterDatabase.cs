using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.DataBase;
using MoneyManager.Core.DataBase.Config;
using System.Text;

namespace MoneyManager.Core.RegistrationServices
{
    public static class RegisterDatabase
    {
        public static void AddDatabase(this IServiceCollection provider)
        {
            DataBaseConfig config = provider
               .BuildServiceProvider()
               //.GetRequiredService<IOptions<DataBaseConfig>>()
               .GetRequiredService<DataBaseConfig>()
               //.Value;
               ;

            switch (config.Type)
            {
                case DataBaseType.SQLite:
                    RegisterSQLite(provider, config);
                    return;
                case DataBaseType.PostgresSQL:
                    RegisterPostgresSQL(provider, config);
                    return;
                default:
                    // TODO log 
                    throw new ArgumentException("No supported database type in config");
            }
        }

        private static void RegisterSQLite(this IServiceCollection provider, DataBaseConfig config)
        {
            provider.AddDbContextFactory<AppDbContext>(_ => _
                .UseSqlite(PrepareConnectionString(config))
                .LogTo(Console.WriteLine, config.LogLevel));
        }

        private static void RegisterPostgresSQL(this IServiceCollection provider, DataBaseConfig config)
        {
            provider.AddDbContextFactory<AppDbContext>(_ => _
                .UseNpgsql(PrepareConnectionString(config))
                .LogTo(Console.WriteLine, config.LogLevel));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        private static string PrepareConnectionString(DataBaseConfig config)
        {
            var sb = new StringBuilder(config.ConnectionString);
            // пока так тупо прибито гвоздями
            try
            {
                sb.Replace($"{{{nameof(DataBaseConfig.Name).ToLower()}}}", config.Name);
                if (config.Network is not null)
                {
                    sb.Replace($"{{{nameof(DataBaseNetwork.Host).ToLower()}}}", config.Network[0].Host);
                    sb.Replace($"{{{nameof(DataBaseNetwork.Port).ToLower()}}}", config.Network[0].Port);
                }
                if (config.Credential is not null)
                {
                    sb.Replace($"{{{nameof(DataBaseCredential.Username).ToLower()}}}", config.Credential[0].Username);
                    sb.Replace($"{{{nameof(DataBaseCredential.Password).ToLower()}}}", config.Credential[0].Password);
                    sb.Replace($"{{{nameof(DataBaseCredential.Schema).ToLower()}}}", config.Credential[0].Schema);
                }
            }
            catch (Exception ex)
            {
                // TODO log
                throw;
            }

            return sb.ToString();
        }
    }
}
