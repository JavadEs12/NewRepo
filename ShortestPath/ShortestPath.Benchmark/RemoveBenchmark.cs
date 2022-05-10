using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Configs;
using ShortestPath;

namespace ShortestPath.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class RemoveBenchmark
    {
        public Dictionary<string,Node> HeapElements { get; set; }
        public ArrayHeap xx { get; set; }

        public RemoveBenchmark()
        {
            HeapElements = new Dictionary<string,Node>();
        }

        public Dictionary<string, Node> GenerateRandomNodes()
        {
            Dictionary<string,Node> Nodes = new Dictionary<string, Node>();
            Random rnd = new Random(0);
            for (int i = 0; i < 5; i += 1)
            {
                Node node = new(i.ToString(), rnd.NextDouble());
                Nodes.Add(i.ToString(), node);
            }
            return Nodes;
        }

        [GlobalSetup]
        public void Init()
        {
            HeapElements = GenerateRandomNodes();
            xx = new ArrayHeap(HeapElements);

        }

        [Benchmark]
        public void ArrayHeapRemove()
        {
            while (xx.count > 1)
            {
                xx.Remove();
            }
        }
    }
}
