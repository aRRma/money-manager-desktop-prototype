using Allure.Net.Commons;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.DataBase;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.Tests.NUnit.Constants;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using System.Linq;
using AllureConstants = MoneyManager.Core.Tests.NUnit.Constants.AllureConstants;

namespace MoneyManager.Core.Tests.NUnit.DataBase
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite(AllureConstants.SuiteDatabase)]
    [AllureParentSuite(AllureConstants.VersionOne)]
    [AllureSubSuite(AllureConstants.SuiteDatabaseDbContext)]
    [AllureTag(AllureConstants.VersionOne, AllureConstants.SuiteDatabase, AllureConstants.SuiteDatabaseDbContext)]
    [AllureSeverity(SeverityLevel.normal)]
    internal class DbContextTest
    {
        private const string DB_NAME = DatabaseConstants.DEFAULT_DB_NAME;

        private readonly DbContextOptionsBuilder<AppDbContext> _dbContextOptionsBuilder;
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public DbContextTest()
        {
            _dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseSqlite($"Data Source = {DB_NAME}");
            _dbContextOptions = _dbContextOptionsBuilder.Options;
        }

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            // запускается единожды перед пачкой тестов
        }

        [SetUp]
        public void SetUpBeforeTest()
        {
            // запускается перед каждым тестом
        }

        [OneTimeTearDown]
        public void TearDownOnce()
        {
            // запускается единожды после пачки тестов
        }

        [TearDown]
        public void TearDownBeforeTest()
        {
            // запускается после каждого теста
        }

        [Test, Order(0)]
        [AllureDescription("Проверка успешного создания базы")]
        public void DbContext_Create_WhenDone()
        {
            using var dbContext = new AppDbContext(_dbContextOptions, true);

            Assert.IsTrue(File.Exists(DB_NAME));
        }

        [Test]
        [AllureDescription("Проверка выборки из ранее созданной базы")]
        public void DbContext_SelectData_WnenDone()
        {
            using var dbContext = new AppDbContext(_dbContextOptions, true);

            var props = dbContext.GetType().GetProperties();

            foreach (var item in props)
            {
                if (item.GetValue(dbContext) is IQueryable<IEfNamedEntity> data)
                {
                    var material = data?.ToList();
                    Assert.Greater(material.Capacity, 0);
                }
            }
        }
    }
}
