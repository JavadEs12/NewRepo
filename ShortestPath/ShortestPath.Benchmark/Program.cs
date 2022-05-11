using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ShortestPath;
namespace ShortestPath.Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            var comparison = new Comparison();
            comparison.NumberOfElements = 10;
            comparison.Init();
            for (int i = 0; i < 10; i++)
            {
                comparison.IterationSetup();
                comparison.HeapAdd();
                comparison.IterationCleanup();
                comparison.IterationSetup();
                comparison.HeapRemove();
                comparison.IterationCleanup();
                comparison.IterationSetup();
                comparison.ArrayHeapAdd();
                comparison.IterationCleanup();
                comparison.IterationSetup();
                comparison.ArrayHeapRemove();
                comparison.IterationCleanup();
            }
            comparison.Cleanup();
#else
            BenchmarkRunner.Run<HeapComparison>(); 
#endif
        }
    }
}