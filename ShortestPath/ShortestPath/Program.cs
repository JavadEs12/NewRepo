namespace ShortestPath
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("ShortestPathInput.txt");
            Deserializer deserializer = new DeserializeRawString(input);
            List<Arc> arcs = deserializer.Deserialize();

            NetworkBuilder networkBuilder = new NetworkBuilder();
            Network network = networkBuilder.BuildNetwork(arcs);

            UserInput userInput = new UserInput();
            (string Origin, string Destination) = userInput.ReadUserInput();

            DijkstraAlgorithm Dijkstra = new DijkstraAlgorithm(new HeapFactory(HeapFactory.HeapType.ArrayHeap)); // Type of heap for heap-interface is assigned here
            Dijkstra.FindShortestPath(network, Origin, Destination);
        }
    }
}