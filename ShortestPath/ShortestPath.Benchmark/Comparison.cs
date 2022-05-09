using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using ShortestPath;

namespace Benchmark
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Comparison
    {
        public Network network;
        public Heap heap = new Heap();
        ArrayHeap arrayHeap = new ArrayHeap();
        public void ReadJson()
        {
            var input = File.ReadAllText("ShortestPathInput.txt");
            var deserializer = new JsonDeserializer();
            List<Arc> arcs = deserializer.Deserialize(input);

            var networkBuilder = new NetworkBuilder();
            network = networkBuilder.BuildNetwork(arcs);
        }
        [Benchmark]
        public void ArrayHeapBenchmark()
        {
            ReadJson();
            arrayHeap = new ArrayHeap(network.Nodes);
        }
        [Benchmark]
        public void HeapBenchmark()
        {
            ReadJson();
            heap = new Heap(network.Nodes);
        }
    }
}
