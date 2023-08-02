using BenchmarkDotNet.Running;

namespace PdfConcat.Benchmark
{
    public class Program
    {
        public static void Main()
        {
            _ = BenchmarkRunner.Run<BenchmarkHelper>();
        }
    }
}
