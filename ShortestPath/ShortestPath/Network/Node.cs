namespace ShortestPath
{
    public class Node

    {
        public string ID { get; set; }
        public double Cost { get; set; }
        public string Successor { get; set; }

        public Node(string id, double cost, string successor)
        {
            ID = id;
            Cost = cost;
            Successor = successor;
        }
        public Node(string id, double cost)
        {
            ID = id;
            Cost = cost;
        }
    }
}
