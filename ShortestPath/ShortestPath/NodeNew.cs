namespace ShortestPath
{
    public class NodeNew
    {
        public string ID { get; set; }
        public double Cost { get; set; }
        public string Successor { get; set; }

        public NodeNew(string ID, double Cost, string Successor)
        {
            this.ID = ID;
            this.Cost = Cost;
            this.Successor = Successor;
        }

        public NodeNew(string ID, double Cost)
        {
            this.ID = ID;
            this.Cost = Cost;
        }
    }
}
