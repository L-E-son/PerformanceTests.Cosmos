using BenchmarkDotNet.Running;

namespace PerformanceTests.Cosmos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}