using Allure.Net.Commons;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.Tests.NUnit.Helpers;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using AllureConstants = MoneyManager.Core.Tests.NUnit.Constants.AllureConstants;

#pragma warning disable CS0618 // Тип или член устарел
namespace MoneyManager.Core.Tests.NUnit.DataBase.CrudTests
{
    [TestFixture(Author = AllureConstants.AuthorArrma, Description = "Проверка сырой выборки сущностей из базы")]
    [AllureNUnit]
    [AllureSuite(AllureConstants.SuiteDatabase)]
    [AllureParentSuite(AllureConstants.VersionOne)]
    [AllureSubSuite(AllureConstants.SuiteDatabaseRawCrud)]
    [AllureTag(AllureConstants.VersionOne, AllureConstants.SuiteDatabase, AllureConstants.SuiteDatabaseRawCrud)]
    [AllureSeverity(SeverityLevel.normal)]
    internal class Database_CreateEntityTests
    {
        [Test]
        [AllureDescription("Проверка успешного создания простых сущностей")]
        public async Task Create_AddSimpleEntity_WhenDone()
        {
            using var context = DbContextTestHelpers.CreateAppDbContext();

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                context.MoneyOperations.Add(EfMoneyOperation.GetDefaultEntity());
                var count = await context.SaveChangesAsync();
                Assert.AreEqual(count, 1);
            }, $"Создание сущности [{nameof(EfMoneyOperation)}]");

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                context.MoneySources.Add(EfMoneySource.GetDefaultEntity());
                var count = await context.SaveChangesAsync();
                Assert.AreEqual(count, 1);
            }, $"Создание сущности [{nameof(EfMoneySource)}]");

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                context.MetaLabels.Add(EfMetaLabel.GetDefaultEntity());
                var count = await context.SaveChangesAsync();
                Assert.AreEqual(count, 1);
            }, $"Создание сущности [{nameof(EfMetaLabel)}]");
        }
    }
}
