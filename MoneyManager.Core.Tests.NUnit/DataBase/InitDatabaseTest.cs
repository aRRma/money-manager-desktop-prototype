using MoneyManager.Core.Tests.NUnit.Constants;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using AllureConstants = MoneyManager.Core.Tests.NUnit.Constants.AllureConstants;

namespace MoneyManager.Core.Tests.NUnit.DataBase
{
    [TestFixture, Order(0)]
    [AllureNUnit]
    [AllureSuite(AllureConstants.SuiteDatabase)]
    [AllureParentSuite(AllureConstants.VersionOne)]
    [AllureTag(AllureConstants.VersionOne, AllureConstants.SuiteDatabase, AllureConstants.SuiteDatabaseDbContext)]
    internal class InitDatabaseTest
    {
        private const string DB_NAME = DatabaseConstants.DEFAULT_DB_NAME;

        [Test, Order(0)]
        [AllureDescription("Удаление старой базы перед стартом тестов")]
        public void Database_Init()
        {
            if (File.Exists(DB_NAME))
                File.Delete(DB_NAME);

            Assert.IsFalse(File.Exists(DB_NAME));
        }
    }
}
