using Allure.Net.Commons;
using MoneyManager.Core.Constants;
using MoneyManager.Core.DataBase.Exceptions;
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
    [TestFixture(Author = AllureConstants.AuthorArrma, Description = $"Проверка работы репозитория {nameof(EfBaseCategoryRepository)}")]
    [AllureNUnit]
    [AllureSuite(AllureConstants.SuiteDatabase)]
    [AllureParentSuite(AllureConstants.VersionOne)]
    [AllureSubSuite(AllureConstants.SuiteDatabaseRepository)]
    [AllureTag(AllureConstants.VersionOne, AllureConstants.SuiteDatabase, AllureConstants.SuiteDatabaseRepository)]
    [AllureSeverity(SeverityLevel.critical)]
    internal class Database_BaseCategoryRepositoryTests
    {
        [Test]
        [AllureDescription("Проверка успешного создания базовой категории через репозиторий")]
        public async Task CategoryRepository_AddBaseCategory_WhenDone()
        {
            using var context = DbContextTestHelpers.CreateAppDbContext();
            var repository = new EfBaseCategoryRepository(context, null, null);

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                var entity = EfBaseCategory.GetDefaultEntity();

                Assert.AreEqual(0, entity.Id);

                var result = await repository.BaseCategoryAddAsync(entity).ConfigureAwait(false);

                Assert.IsTrue(result.Id != 0);
                Assert.AreNotEqual(0, entity.Id);
            }, "Добавление в репозиторий новой базовой категории");
        }

        [Test]
        [AllureDescription("Проверка типа эксепшена при попытке добавлении дублирующей сущности (одинаковый 'name')")]
        public async Task CategoryRepository_AddDuplicateNameBaseCategory_WhenDuplicateException()
        {
            using var context = DbContextTestHelpers.CreateAppDbContext();
            var constProvider = new AppDbExceptionConstantProvider();
            var repository = new EfBaseCategoryRepository(context, null, constProvider);

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                var entity = EfBaseCategory.GetDefaultEntity();

                Assert.AreEqual(0, entity.Id);

                var result = await repository.BaseCategoryAddAsync(entity).ConfigureAwait(false);

                Assert.IsTrue(result.Id != 0);
                Assert.IsTrue(entity.Id != 0);
            }, "Добавление в репозиторий новой базовой категории");

            AllureLifecycle.Instance.WrapInStep(() =>
            {
                var entity = EfBaseCategory.GetDefaultEntity();

                Assert.AreEqual(0, entity.Id);
                var ex = Assert.ThrowsAsync<DuplicateEntityException>(async ()
                    => await repository.BaseCategoryAddAsync(entity).ConfigureAwait(false));
                Assert.IsTrue(ex.Message.Contains("name"));
                Assert.IsTrue(ex.Message.Contains($"{nameof(EfBaseCategory)}"));

                Console.WriteLine(ex.Message);
            }, "Попытка повторного добавления в репозиторий дублирующей базовой категории");
        }

        [Test]
        [AllureDescription("Проверка типа эксепшена при попытке добавлении дублирующей сущности (одинаковый 'id')")]
        public async Task CategoryRepository_AddDuplicateIdBaseCategory_WhenDuplicateException()
        {
            using var context = DbContextTestHelpers.CreateAppDbContext();
            var constProvider = new AppDbExceptionConstantProvider();
            var repository = new EfBaseCategoryRepository(context, null, constProvider);
            var entity = EfBaseCategory.GetDefaultEntity();

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                Assert.AreEqual(0, entity.Id);

                var result = await repository.BaseCategoryAddAsync(entity).ConfigureAwait(false);

                Assert.IsTrue(result.Id != 0);
                Assert.IsTrue(entity.Id != 0);
            }, "Добавление в репозиторий новой базовой категории");

            AllureLifecycle.Instance.WrapInStep(() =>
            {
                entity.Name = "Some";

                var ex = Assert.ThrowsAsync<DuplicateEntityException>(async ()
                    => await repository.BaseCategoryAddAsync(entity).ConfigureAwait(false));
                Assert.IsTrue(ex.Message.Contains("id"));
                Assert.IsTrue(ex.Message.Contains($"{nameof(EfBaseCategory)}"));

                Console.WriteLine(ex.Message);
            }, "Попытка повторного добавления в репозиторий дублирующей базовой категории");
        }

        [Test]
        [AllureDescription("Проверка успешного удаление сущности через репозиторий")]
        public async Task CategoryRepository_DeleteExistEntityBaseCategory_WhenDone()
        {
            using var context = DbContextTestHelpers.CreateAppDbContext();
            var repository = new EfBaseCategoryRepository(context, null, null);
            var entity = EfBaseCategory.GetDefaultEntity();

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                Assert.AreEqual(0, entity.Id);

                var result = await repository.BaseCategoryAddAsync(entity).ConfigureAwait(false);

                Assert.IsTrue(result.Id != 0);
                Assert.IsTrue(entity.Id != 0);
            }, "Добавление в репозиторий новой базовой категории");

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                var result = await repository.BaseCategoryRemoveAsync(entity).ConfigureAwait(false);

                Assert.IsTrue(result);
            }, "Попытка удаления ранее добавленной базовой категории");

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                var result = await repository.ExistByIdAsync(entity.Id).ConfigureAwait(false);

                Assert.IsFalse(result);
            }, "Проверка что категория удалилась");
        }

        [Test]
        [AllureDescription("Проверка удаление не существующей сущности через репозиторий")]
        public async Task CategoryRepository_DeleteNotExistEntityBaseCategory_WhenFalse()
        {
            using var context = DbContextTestHelpers.CreateAppDbContext();
            var repository = new EfBaseCategoryRepository(context, null, null);
            var entity = EfBaseCategory.GetDefaultEntity();
            entity.Id = 1000;

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                var result = await repository.BaseCategoryRemoveAsync(entity).ConfigureAwait(false);

                Assert.IsFalse(result);
            }, "Попытка удаления ранее добавленной базовой категории");
        }
    }
}
