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
            var path = new ShortestPath(new HeapFactory(HeapFactory.HeapType.ArrayHeap));
            List<string> shortestPath = path.FindShortestPath(network, Origin, Destination);
            Print(shortestPath);
        }
        private static void Print(List<string> shortestPath)
        {
            Console.WriteLine($"Sequence of shortest path elements are as:");
            foreach (string node in shortestPath)
            {
                Console.WriteLine(node);
            }
        }
    }
}