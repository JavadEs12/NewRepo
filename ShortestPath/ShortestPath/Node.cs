namespace ShortestPath
{
    public class Node
    {
        public string ID { get; set; }
        public double Cost { get; set; }
        public string Successor { get; set; }

        public static Dictionary<string, Node> NetworkNodes = new Dictionary<string, Node>();
        public Node Parent;
        public Node Left;
        public Node Right;

        public Node(string ID, double Cost, string Successor)
        {
            this.ID = ID;
            this.Cost = Cost;
            this.Successor = Successor;
        }
        public Node(string id, double cost)
        {
            ID = id;
            Cost = cost;
        }
        public Node(Node parent)
        {
            Parent = parent;
        }
    }
}
