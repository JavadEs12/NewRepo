using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Configs;

using Newtonsoft.Json;
using ShortestPath;

namespace ShortestPath.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class HeapComparison
    {

        [Params(10,100,1000,10000)]
        public int NumberOfElements { get; set; }

        public List<Node> nodes { get; set; }
        public ArrayHeap arrayHeap { get; set; }
        public Heap heap { get; set; }

        [GlobalSetup]
        public void Init()
        {
            nodes = GenerateRandomNodes();
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            nodes = null;
        }

        [IterationSetup]
        public void IterationSetup()
        {
            arrayHeap = new ArrayHeap();
            nodes.ForEach(x => arrayHeap.Add(x));
            heap = new Heap();
            nodes.ForEach(x => heap.Add(x));
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            arrayHeap = null;
            heap = null;
        }

        public List<Node> GenerateRandomNodes()
        {
            List<Node> Nodes = new List<Node>();
            Random rnd = new Random(0);
            for (int i = 0; i < NumberOfElements; i += 1)
            {
                Node node = new(i.ToString(), rnd.NextDouble());
                Nodes.Add(node);
            }
            return Nodes;
        }

        [Benchmark]
        public void HeapAdd()
        {
            nodes.ForEach(x => heap.Add(x));
        }

        [Benchmark]
        public void ArrayHeapAdd()
        {
            nodes.ForEach(x => arrayHeap.Add(x));
        }

        [Benchmark]
        public void HeapRemove()
        {
            while (heap.count > 1)
            {
                heap.Remove();
            }
        }

        [Benchmark]
        public void ArrayHeapRemove()
        {
            while (arrayHeap.count > 1)
            {
                arrayHeap.Remove();
            }
        }
    }
}
