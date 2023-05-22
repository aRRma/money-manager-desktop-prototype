using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using AllureConstants = MoneyManager.Core.Tests.NUnit.Constants.AllureConstants;

namespace MoneyManager.Core.Tests.NUnit.DataBase
{
    [AllureNUnit]
    [AllureSuite(AllureConstants.VersionOne)]
    [AllureParentSuite(AllureConstants.SuiteDatabase)]
    [TestFixture(TestName = "InitBeforeDataBaseIsTesting", Author = AllureConstants.AuthorArrma, Category = AllureConstants.CategoryDatabase), Order(0)]
    internal class InitDatabaseTest
    {
        [Test(Description = "Инициализация базы данных"), Order(0)]
        public void InitDatabase()
        {
            // удалить старую базу под ногами
            // создать контекст
            // создать базу
        }
    }
}
