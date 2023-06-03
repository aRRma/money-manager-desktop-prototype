using Allure.Net.Commons;
using MoneyManager.Core.DataBase;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Enums;
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
            var dbName = default(string);
            using var dbContext = AllureLifecycle.Instance.WrapInStep(() =>
            {
                var options = DbContextHelpers.GetDataBaseOptions<AppDbContext>(out dbName);
                var dbContext = new AppDbContext(options, true);
                Console.WriteLine($"Create base [{dbName}]");
                return dbContext;
            }, "Создание контекста и базы данных");

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                dbContext.MoneyOperations.Add(new EfMoneyOperation()
                {
                    CreateDate = DateTime.Now,
                    DeleteDate = DateTime.Now,
                    Name = "Test",
                    OperationType = MoneyOperationType.INCOME,
                    Uuid = Guid.NewGuid()
                });
                var count = await dbContext.SaveChangesAsync();
                Assert.AreEqual(count, 1);
            }, $"Создание сущности [{nameof(EfMoneyOperation)}]");

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                dbContext.MoneySources.Add(new EfMoneySource()
                {
                    CreateDate = DateTime.Now,
                    DeleteDate = DateTime.Now,
                    Name = "Test",
                    SourceType = MoneySourceType.CASH,
                    Uuid = Guid.NewGuid()
                });
                var count = await dbContext.SaveChangesAsync();
                Assert.AreEqual(count, 1);
            }, $"Создание сущности [{nameof(EfMoneySource)}]");

            await AllureLifecycle.Instance.WrapInStepAsync(async () =>
            {
                dbContext.MetaLabels.Add(new EfMetaLabel()
                {
                    CreateDate = DateTime.Now,
                    DeleteDate = DateTime.Now,
                    Name = "Test",
                    RecordLabel = MetaLabelType.EAT,
                    Uuid = Guid.NewGuid()                    
                });
                var count = await dbContext.SaveChangesAsync();
                Assert.AreEqual(count, 1);
            }, $"Создание сущности [{nameof(EfMetaLabel)}]");
        }
    }
}
