using Allure.Net.Commons;
using NUnit.Framework;
using System.Diagnostics;

namespace MoneyManager.Core.Tests.NUnit
{
    [SetUpFixture]
    internal class GlobalInitializationOfTests
    {
        private readonly string CMD_PATH = Path.Combine("C:\\Windows\\System32", "cmd.exe");
        private readonly string ALLURE_RESULT_PATH = Path.Combine("./allure-results");

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
            // должен быть установлен allure и добавлен путь до него в окружение
            var cmd = new Process();
            cmd.StartInfo.FileName = CMD_PATH;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine($"allure serve {ALLURE_RESULT_PATH}");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
        }
    }
}
