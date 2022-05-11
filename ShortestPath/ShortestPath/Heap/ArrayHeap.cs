namespace ShortestPath
{
    public class ArrayHeap : IHeap
    {
        public List<Node> heap = new();
        public int count;
        public Node Root => heap[0];
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
            heap.Add(node);
            count++;
            PerculateUp();
            Validate();
        }
        public void PerculateUp()
        {
            if (count == 0) 
            {
                return; 
            }
            else
            {
                int pointer = count - 1;
                while (true)
                {
                    Node Child = heap[pointer];
                    var parentIndex = (pointer - 1)/2;
                    Node Parent = heap[parentIndex]; //Maybe need to round down 
                    if (Child.Cost < Parent.Cost)
                    {
                        Swap(parentIndex, pointer);
                    }
                    pointer = parentIndex;
                    if (pointer == 0) 
                    { 
                        break;
                    }
                }
            }
        }

        private void Validate()
        {
            if (heap.Count == 0)
            {
                return;
            }
            var lowCost = Root.Cost;
            if (heap.Any(x => x.Cost < lowCost))
            {
                throw new InvalidOperationException();
            }
            for (int i = 0; i < count / 2; i++)
            {
                var l = 2 * i + 1;
                if (l < count)
                {
                    if (heap[l].Cost < heap[i].Cost)
                    {
                        throw new InvalidOperationException();
                    }

                }
                var r = 2 * i + 2;
                if (r < count)
                {
                    if (heap[r].Cost < heap[i].Cost)
                    {
                        throw new InvalidOperationException();
                    }

                }
            }

        }

        public Node Remove()
        {
            Node Root = heap[0];
            heap[0] = heap[count - 1];
            heap.RemoveAt(count - 1);
            count--;
            PerculateDown();
            Validate();
            return Root;
        }
        public void PerculateDown()
        {
            int pointer = 0;
            int compare;

            while (true)
            {
                if (2 * pointer + 1 > heap.Count - 1)
                {
                    break;
                }
                if (2 * pointer + 2 > heap.Count - 1)
                {
                    compare = 2 * pointer + 1;
                }
                else
                {
                    Node? Parent = heap[pointer];
                    Node? LChild = heap[(2 * pointer + 1)];
                    Node? RChild = heap[(2 * pointer + 2)];
                    if (RChild.Cost > LChild.Cost)
                    {
                        compare = 2 * pointer + 1;
                    }
                    else
                    {
                        compare = 2 * pointer + 2;
                    }
                }
                if (heap[pointer].Cost > heap[compare].Cost)
                {
                    Swap(pointer, compare);
                    //(heap[pointer], heap[compare]) = (heap[compare], heap[pointer]);
                    pointer = compare;
                }
                else
                {
                    break;
                }
            }
        }

        public void Swap(int parentIndex, int childIndex)
        {
            // Swap by tuple feature
            (heap[childIndex], heap[parentIndex]) = (heap[parentIndex], heap[childIndex]);
        }
    }
}
