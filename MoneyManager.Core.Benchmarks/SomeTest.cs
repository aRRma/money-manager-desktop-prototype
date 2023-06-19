using BenchmarkDotNet.Attributes;
using MoneyManager.Core.DataBase.Models;

namespace MoneyManager.Core.Benchmarks
{
    [MemoryDiagnoser]
    public class SomeTest
    {
        private EfMoneyOperation entity;
        private List<EfRecord> list;

        [IterationSetup]
        public void Setup()
        {
            entity = EfMoneyOperation.GetDefaultEntity();

            list = new List<EfRecord>();
            for (int i = 0; i < 100; i++)
                list.Add(EfRecord.GetDefaultEntity());
        }

        [Benchmark, IterationCount(5)]
        public void Test1()
        {
            Program.DbContext.MoneyOperations.Add(entity);
        }

        [Benchmark, IterationCount(5)]
        public void Test2()
        {
            entity = EfMoneyOperation.GetDefaultEntity();
            Program.DbContext.MoneyOperations.Add(entity);
        }

        [Benchmark, IterationCount(5)]
        public void Test3()
        {
            Program.DbContext.Records.AddRange(list);
        }

        [Benchmark, IterationCount(5)]
        public void Test4()
        {
            list = new List<EfRecord>();

            for (int i = 0; i < 100; i++)
                list.Add(EfRecord.GetDefaultEntity());

            Program.DbContext.Records.AddRange(list);
        }
    }
}
