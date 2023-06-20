using Allure.Net.Commons;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.Tests.NUnit.Helpers;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using AllureConstants = MoneyManager.Core.Tests.NUnit.Constants.AllureConstants;

#pragma warning disable CS0618 // Тип или член устарел
namespace MoneyManager.Core.Tests.NUnit.DataBase
{
    [TestFixture(Author = AllureConstants.AuthorArrma, Description = "Проверка создания DbContext'a и базы")]
    [AllureNUnit]
    [AllureSuite(AllureConstants.SuiteDatabase)]
    [AllureParentSuite(AllureConstants.VersionOne)]
    [AllureSubSuite(AllureConstants.SuiteDatabaseDbContext)]
    [AllureTag(AllureConstants.VersionOne, AllureConstants.SuiteDatabase, AllureConstants.SuiteDatabaseDbContext)]
    [AllureSeverity(SeverityLevel.critical)]
    internal class Database_DbContextTests
    {
        public Database_DbContextTests()
        {
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
        public void TearDownAfterTest()
        {
            // запускается после каждого теста
        }

        [Test, Order(0)]
        [AllureDescription("Проверка успешного создания базы")]
        public void DbContext_Create_WhenDone()
        {
            using var context = DbContextTestHelpers.CreateAppDbContext();
            var dbName = DbContextTestHelpers.GetDbNameFromDbContext(context);

            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Assert.IsTrue(File.Exists(dbName));
                Console.WriteLine($"Base [{dbName}] is exist");
            }, "Проверка что база успешно создалась");
        }

        [Test]
        [AllureDescription("Проверка выборки из ранее созданной базы")]
        public void DbContext_CreateAndSelectData_WhenDone()
        {
            // TODO переделать на коннект к базе
            using var context = DbContextTestHelpers.CreateAppDbContext();

            AllureLifecycle.Instance.WrapInStep(() =>
            {
                var props = context.GetType().GetProperties();

                foreach (var item in props)
                {
                    if (item.GetValue(context) is IQueryable<IEfNamedEntity> data)
                    {
                        var material = data?.ToList();
                        Console.WriteLine($"DbSet name - [{item.Name}], count - [{material.Capacity}]");
                        Assert.Greater(material.Capacity, 0);
                    }
                }
            }, "Выборка данных из всех DbSet'ов контекста и проверка что записей больше 0");
        }
    }
}
