namespace ShortestPath
{
    public class ArrayHeap : IHeap
    {
        public List<Node> Heap = new();
        private int count;
        public Node Root => Heap[0];
        public ArrayHeap(Dictionary<string, Node> nodes)
        {
            this.count = 0;
            foreach (KeyValuePair<string, Node> node in nodes)
            {
                Add(node.Value);
            }
        }
        public ArrayHeap() { }
        public void Add(Node node)
        {
            Heap.Add(node);
            count++;
            PerculateUp();
        }
        private void PerculateUp()
        {
            if (count == 0) { return; }
            else
            {
                int pointer = count - 1;
                while (true)
                {
                    Node? Child = Heap[pointer];
                    Node? Parent = Heap[Math.Abs((pointer) / 2)]; //Maybe need to round down 
                    if (Child.Cost < Parent.Cost)
                    {
                        Swap(Math.Abs((pointer) / 2), pointer);
                    }
                    pointer = Math.Abs((pointer) / 2);
                    if (pointer == 0) { break; }
                }
            }
        }
        public Node Remove()
        {
            Node? Root = Heap[0];
            Heap[0] = Heap[count - 1];
            Heap.RemoveAt(count - 1);
            count--;
            PerculateDown();
            return Root;
        }
        private void PerculateDown()
        {
            int pointer = 0;
            while (true)
            {
                if (Heap.Count == 0) { break; }
                Node? Parent = Heap[pointer];
                Node? LChild = null;
                Node? RChild = null;
                if ((2 * pointer + 1 <= count - 1))
                { LChild = Heap[2 * pointer + 1]; }
                if ((2 * pointer + 2 <= count - 1))
                { RChild = Heap[2 * pointer + 2]; }
                if (LChild == null) { break; }
                if (RChild == null)
                {
                    if (Parent.Cost > LChild.Cost)
                    {
                        Swap(pointer, (2 * pointer + 1));
                    }
                    break;
                }
                else if (Parent.Cost > LChild.Cost || Parent.Cost > RChild.Cost)
                {
                    if (LChild.Cost < RChild.Cost)
                    {
                        Swap(pointer, (2 * pointer + 1));
                        pointer = 2 * pointer + 1;
                    }
                    else
                    {
                        Swap(pointer, (2 * pointer + 2));
                        pointer = 2 * pointer + 2;
                    }
                }
            }
        }
        private void Swap(int parentIndex, int childIndex)
        {
            // Swap by tuple feature
            (Heap[childIndex], Heap[parentIndex]) = (Heap[parentIndex], Heap[childIndex]);
        }
    }
}
