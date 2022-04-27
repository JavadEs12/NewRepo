using Newtonsoft.Json;

namespace ShortestPath
{
    public class Program
    {
        public static string Origin;
        public static string Destination;

        static void Main(string[] args)
        {
            List<Arc> arcs = Reading_Input_Data();
            Network network = new Network();
            NetworkBuilder networkBuilder = new NetworkBuilder();
            networkBuilder.Network_Building(network, arcs);

            (Origin, Destination) = UserInput();
            Search search = new Search();
            search.ShortestPath(network);
        }

        private static List<Arc> Reading_Input_Data()
        {
            return JsonConvert.DeserializeObject<List<Arc>>(File.ReadAllText("C:/Users/j.eslamibabaheidari/source/repos/JavadEs12/NewRepo/ShortestPath/ShortestPathInput.txt"));
        }

        private static (string, string) UserInput()
        {
            Console.WriteLine("Please choose your Origin-Destination couple\nYou are allowed to choose numbers between 1-6");
            Origin = InputAccuracy();
            Destination = InputAccuracy();
            return (Origin, Destination);
        }

        private static string InputAccuracy()
        {
            while (true)
            {
                try
                {
                    var input = Int16.Parse(Console.ReadLine());
                    if (Origin == null && input >= 1 && input <= 6)
                    {
                        return input.ToString();
                    }
                    else if (Origin != null && input >= 1 && input <= 6)
                    {
                        if (input.ToString() == Origin)
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