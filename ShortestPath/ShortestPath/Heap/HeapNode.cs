namespace ShortestPath
{
    public class HeapNode
    {
        public string ID { get; set; }
        public double Cost { get; set; }
        public HeapNode Parent;
        public HeapNode Left;
        public HeapNode Right;

        public HeapNode(string id, double cost)
        {
            ID = id;
            Cost = cost;
        }
        public HeapNode(HeapNode parent)
        {
            Parent = parent;
        }
    }
}
