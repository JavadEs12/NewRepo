using Newtonsoft.Json;

namespace ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Arc arc1 = new Arc();
            Search search1 = new Search();

            Program program = new Program();
            program.InputData(search1);
            Node node1 = new Node();
            Implementation(arc1, search1, node1);
        }
        static void Implementation(Arc arc1, Search search1, Node node1)
        {
            arc1.arcs = JsonConvert.DeserializeObject<List<Arc>>(File.ReadAllText("D:/ShortestPath/ShortestPathInput.txt"));
            arc1.NodeAssignment(node1);

            search1.ShortestPath(node1, arc1);
        }

        private void InputData(Search search1)
        {
            Console.WriteLine("Please choose your Origin-Destination couple\nYou are allowed to choose numbers between 1-6");
            search1.Origin = InputAccuracy(search1);
            search1.Destination = InputAccuracy(search1);
            search1.MainDestination = search1.Destination;
        }

        private string InputAccuracy(Search search1)
        {
            while (true)
            {
                int input = Int16.Parse(Console.ReadLine());
                if (search1.Origin == null && input >= 1 && input <= 6)
                {
                    return input.ToString();
                }
                else if (search1.Origin != null && input >= 1 && input <= 6)
                {
                    if (input.ToString() == search1.Origin)
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