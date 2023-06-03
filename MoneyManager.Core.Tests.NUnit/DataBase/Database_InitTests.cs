using Allure.Net.Commons;
using MoneyManager.Core.Tests.NUnit.Constants;
using MoneyManager.Core.Tests.NUnit.Helpers;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using AllureConstants = MoneyManager.Core.Tests.NUnit.Constants.AllureConstants;

#pragma warning disable CS0618 // Тип или член устарел
namespace MoneyManager.Core.Tests.NUnit.DataBase
{
    [TestFixture(Author = AllureConstants.AuthorArrma, Description = "Подготовка к тестированию базы"), Order(0)]
    [AllureNUnit]
    [AllureSuite(AllureConstants.SuiteDatabase)]
    [AllureParentSuite(AllureConstants.VersionOne)]
    [AllureTag(AllureConstants.VersionOne, AllureConstants.SuiteDatabase, AllureConstants.SuiteDatabaseDbContext)]
    internal class Database_InitTests
    {
        private const string DB_NAME = DatabaseConstants.DEFAULT_DB_NAME;

        [Test, Order(0)]
        [AllureDescription("Удаление старых баз перед стартом тестов")]
        public void Database_InitCleanOldBase_WhenDone()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                DbContextHelpers.DeleteAllDbWithTestExtension();
            }, "Удаление всех тестовых баз");

            if (File.Exists(DB_NAME))
                File.Delete(DB_NAME);

            Assert.IsFalse(File.Exists(DB_NAME));
        }
    }
}
