using Newtonsoft.Json;

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


            (string Origin, string Destination) = ImportUserInput();
            DijkstraAlgorithm Dijkstra = new DijkstraAlgorithm(new HeapFactory(HeapFactory.HeapType.ArrayHeap)); // Type of heap for heap-interface is assigned here
            Dijkstra.FindShortestPath(network, Origin, Destination);
        }

        private static List<Arc> ImportNetworkData()
        {
            string input = File.ReadAllText("ShortestPathInput.txt");
            return JsonConvert.DeserializeObject<List<Arc>>(input);
        }

        private static (string, string) ImportUserInput()
        {
            Console.WriteLine("Please choose your Origin-Destination couple\nYou are allowed to choose numbers between 1-6");
            string Origin = CheckInputAccuracy();
            string Destination = CheckInputAccuracy(Origin);
            return (Origin, Destination);
        }

        private static string CheckInputAccuracy(string origin = null)
        {
            while (true)
            {
                try
                {
                    var input = Int16.Parse(Console.ReadLine());
                    if (origin == null && input >= 1 && input <= 6)
                    {
                        return input.ToString();
                    }
                    else if (origin != null && input >= 1 && input <= 6)
                    {
                        if (input.ToString() == origin)
                        {
                            Console.WriteLine("Entered number is repeated, please try another number for destination");
                        }
                        else
                        {
                            return input.ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input data, Please enter a number between 1-6");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
    }
}