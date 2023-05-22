using Allure.Net.Commons;
using NUnit.Framework;

namespace MoneyManager.Core.Tests.NUnit
{
    [SetUpFixture]
    internal class GlobalInitializationOfTests
    {
        /// <summary>
        /// Запускается один раз перед запуском всех тестов
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        /// <summary>
        /// Запускается один раз после завершения всех тестов
        /// </summary>
        [OneTimeTearDown]
        public void TearDown()
        {
            
        }
    }
}
