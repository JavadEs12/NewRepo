namespace ShortestPath
{
    public class Heap
    {
        public string ID { get; set; }
        public double Cost { get; set; }

        public Heap Parent;
        public Heap Left;
        public Heap Right;

        public Heap(string id, double cost)
        {
            ID = id;
            Cost = cost;
        }
        public Heap(Heap parent)
        {
            Parent = parent;
        }
    }
}
