using NUnit.Framework;

namespace MoneyManager.Core.Tests.NUnit.Other
{
    [TestFixture]
    internal class CollectionTests
    {
        [Test]
        [TestCaseSource(
            typeof(CollectionTestsTCD),
            nameof(CollectionTestsTCD.CollectionTests))]
        [NonParallelizable]
        public void IsNotEmptyTests(string data, List<string> list)
        {
            Console.WriteLine(data);
            Assert.IsNotEmpty(list);
        }
    }
}
