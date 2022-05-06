namespace ShortestPath
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("ShortestPathInput.txt");
            var deserializer = new JsonDeserializer();
            List<Arc> arcs = deserializer.Deserialize(input);

            NetworkBuilder networkBuilder = new NetworkBuilder();
            Network network = networkBuilder.BuildNetwork(arcs);

            UserInput userInput = new UserInput();
            (string Origin, string Destination) = userInput.ReadUserInput();

            // Type of heap for heap-interface is assigned here
            DijkstraAlgorithm Dijkstra = new DijkstraAlgorithm(new HeapFactory(HeapFactory.HeapType.ArrayHeap));
            Dijkstra.FindShortestPath(network, Origin, Destination);
        }
    }
}