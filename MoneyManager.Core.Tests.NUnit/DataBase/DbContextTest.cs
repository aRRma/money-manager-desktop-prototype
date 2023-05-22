using Allure.Net.Commons;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.DataBase;
using MoneyManager.Core.Tests.NUnit.Constants;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using AllureConstants = MoneyManager.Core.Tests.NUnit.Constants.AllureConstants;

namespace MoneyManager.Core.Tests.NUnit.DataBase
{
    [AllureNUnit]
    [AllureSuite(AllureConstants.VersionOne)]
    [AllureParentSuite(AllureConstants.SuiteDatabase)]
    [AllureSubSuite(AllureConstants.SuiteDatabaseDbContext)]
    [AllureTag(AllureConstants.VersionOne, AllureConstants.SuiteDatabase, AllureConstants.SuiteDatabaseDbContext)]
    [TestFixture(TestName = "DbContextTesting", Author = AllureConstants.AuthorArrma, Category = AllureConstants.CategoryDatabase)]
    [AllureSeverity(SeverityLevel.normal)]
    internal class DbContextTest
    {
        private const string DB_NAME = DatabaseConstants.DEFAULT_DB_NAME;

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

        [Test(Description = "Мой первый тест :)")]
        [AllureTag("NUnit", "SomeTest")]
        [Parallelizable]
        public void DbContext_Create_Done()
        {
            var contextOpt = new DbContextOptionsBuilder<AppDbContext>().UseSqlite($"Data Source = {DB_NAME}");
            var dbContext = new AppDbContext(contextOpt.Options);

            Assert.IsTrue(File.Exists(DB_NAME));
        }
    }
}
