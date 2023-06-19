using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.DataBase;

namespace MoneyManager.Core.Benchmarks
{
    // dotnet MoneyManager.Core.Benchmarks.dll -c Release

    internal class Program
    {
        public static readonly AppDbContext DbContext;

        private const string DB_NAME = "BenchDb.db";

        static Program()
        {
            var optBuilder = new DbContextOptionsBuilder<AppDbContext>().UseSqlite($"Data Source = {DB_NAME}");
            DbContext = new AppDbContext(optBuilder.Options, true);
        }

        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SomeTest>();
        }
    }
}