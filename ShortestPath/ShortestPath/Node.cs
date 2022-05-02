namespace ShortestPath
{
    public class Node
    {
        public string ID { get; set; }
        public double Cost { get; set; }
        public string Successor { get; set; }

        public Node(string ID, double Cost, string Successor)
        {
            this.ID = ID;
            this.Cost = Cost;
            this.Successor = Successor;
        }

        public Node(string ID, double Cost)
        {
            this.ID = ID;
            this.Cost = Cost;
        }
    }
}
