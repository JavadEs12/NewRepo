using Newtonsoft.Json;

namespace ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shortest Path");
            InputData();
            Implementation();
        }
        static void Implementation()
        {
            Arc.arcs = JsonConvert.DeserializeObject<List<Arc>>(File.ReadAllText("D:/ShortestPath/ShortestPathInput.txt"));

            Arc obj = new Arc();
            obj.NodeAssignment();

            Search obj2 = new Search();
            obj2.ShortestPath();
        }

        static void InputData()
        {
            Console.WriteLine("Please choose your Origin-Destination couple\nYou are allowed to choose numbers between 1-6");
            Search.Origin = InputAccuracy();
            Search.Destination = InputAccuracy();
            Search.MainDestination = Search.Destination;
        }

        static string InputAccuracy()
        {
            while (true)
            {
                int input = Int16.Parse(Console.ReadLine());
                if (Search.Origin == null && input >= 1 && input <= 6)
                {
                    return input.ToString();
                }
                else if (Search.Origin != null && input >= 1 && input <= 6)
                {
                    if (input.ToString() == Search.Origin)
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
        }
    }
}