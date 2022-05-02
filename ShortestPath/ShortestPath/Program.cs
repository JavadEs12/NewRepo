using Newtonsoft.Json;

namespace ShortestPath
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Arc> arcs = ImportNetworkData();
            Network network = new Network();
            NetworkBuilder networkBuilder = new NetworkBuilder();
            networkBuilder.BuildNetwork(network, arcs);


            (string Origin, string Destination) = ImportUserInput();
            DijkstraAlgorithm search = new DijkstraAlgorithm();
            search.FindShortestPath(network, Origin, Destination);
        }

        private static List<Arc> ImportNetworkData()
        {
            return JsonConvert.DeserializeObject<List<Arc>>(File.ReadAllText("ShortestPathInput.txt"));
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