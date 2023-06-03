using Allure.Net.Commons;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository;
using MoneyManager.Core.Tests.NUnit.Helpers;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using AllureConstants = MoneyManager.Core.Tests.NUnit.Constants.AllureConstants;

#pragma warning disable CS0618 // Тип или член устарел
namespace MoneyManager.Core.Tests.NUnit.DataBase.RepositoryTests
{
    [TestFixture(Author = AllureConstants.AuthorArrma, Description = "Проверка работы репозиториев сущностей")]
    [AllureNUnit]
    [AllureSuite(AllureConstants.SuiteDatabase)]
    [AllureParentSuite(AllureConstants.VersionOne)]
    [AllureSubSuite(AllureConstants.SuiteDatabaseRepository)]
    [AllureTag(AllureConstants.VersionOne, AllureConstants.SuiteDatabase, AllureConstants.SuiteDatabaseRepository)]
    [AllureSeverity(SeverityLevel.critical)]
    internal class Database_CategoryRepositoryTests
    {
        [Test]
        [AllureDescription("Проверка успешного создания базовой категории через репозиторий")]
        public async Task CategoryRepository_AddBaseCategory_WhenDone()
        {
            using var context = DbContextTestHelpers.CreateAppDbContext();
            var dbName = DbContextTestHelpers.GetDbNameFromDbContext(context);
            var repository = new EfBaseCategoryRepository(context, null);

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                var entity = EfBaseCategory.GetDefaultEntity();

                Assert.AreEqual(0, entity.Id);

                var result = await repository.BaseCategoryAddAsync(entity).ConfigureAwait(false);

                Assert.IsTrue(result);
                Assert.AreNotEqual(0, entity.Id);
            }, "Добавление в репозиторий новой базовой категории");
        }
    }
}
