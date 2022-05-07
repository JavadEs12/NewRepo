namespace ShortestPath
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("ShortestPathInput.txt");
            var deserializer = new JsonDeserializer();
            List<Arc> arcs = deserializer.Deserialize(input);

            var networkBuilder = new NetworkBuilder();
            var network = networkBuilder.BuildNetwork(arcs);

            var userInput = new UserInput();
            (string Origin, string Destination) = userInput.ReadUserInput();

            // Type of heap for heap-interface is assigned here
            var Dijkstra = new DijkstraAlgorithm(new HeapFactory(HeapFactory.HeapType.Heap));
            Dijkstra.FindShortestPath(network, Origin, Destination);
        }
    }
}