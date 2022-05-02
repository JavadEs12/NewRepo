using Newtonsoft.Json;

namespace ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Arc obj = new Arc();
            DijkstraByNodeHeap obj2 = new DijkstraByNodeHeap();

            Program obj3 = new Program();
            obj3.InputData(obj2);
            Node obj4 = new Node();
            Implementation(obj, obj2, obj4);
        }
        static void Implementation(Arc obj, DijkstraByNodeHeap obj2, Node obj4)
        {
             obj.arcs = JsonConvert.DeserializeObject<List<Arc>>(File.ReadAllText("C:/Users/j.eslamibabaheidari/source/repos/JavadEs12/-DijkstraNew-/ShortestPath/ShortestPathInput.txt"));
            obj.NodeAssignment(obj4);

            obj2.ShortestPath(obj4, obj);
        }

        private void InputData(DijkstraByNodeHeap obj2)
        {
            Console.WriteLine("Please choose your Origin-Destination couple\nYou are allowed to choose numbers between 1-6");
            obj2.Origin = InputAccuracy(obj2);
            obj2.Destination = InputAccuracy(obj2);
            obj2.MainDestination = obj2.Destination;
        }

        private string InputAccuracy(DijkstraByNodeHeap obj2)
        {
            while (true)
            {
                int input = Int16.Parse(Console.ReadLine());
                if (obj2.Origin == null && input >= 1 && input <= 6)
                {
                    return input.ToString();
                }
                else if (obj2.Origin != null && input >= 1 && input <= 6)
                {
                    if (input.ToString() == obj2.Origin)
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