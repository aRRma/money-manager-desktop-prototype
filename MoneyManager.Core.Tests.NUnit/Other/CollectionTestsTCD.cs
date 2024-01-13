using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Tests.NUnit.Other
{
    internal class CollectionTestsTCD
    {
        public static IEnumerable<TestCaseData> CollectionTests()
        {
            var list1 = new List<string>();

            yield return new TestCaseData("Empty LIST", list1);

            var list2 = new List<string>() { "DATA 1" };

            yield return new TestCaseData("With 1 record in LIST", list2);

            List<string> list3 = null;

            yield return new TestCaseData("Null LIST", list3);
        }
    }
}
