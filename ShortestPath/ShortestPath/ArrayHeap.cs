using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public class ArrayHeap
    {
        public List<Node> Heap = new List<Node>();
        private int count;

        public ArrayHeap(Dictionary<string, Node> nodes)
        {
            count = 0;
            foreach (KeyValuePair<string, Node> node in nodes)
            {
                Add(node.Value);
            }
        }
        public void Add(Node node)
        {
            Heap.Add(node);
            count++;
            PerculateUp();
        }

        private void PerculateUp()
        {
            if (Heap.Count == 0) { return; }

            else
            {
                int pointer = count - 1;
                while (true)
                {
                    Node Child = Heap[pointer];
                    Node Parent = Heap[Math.Abs((pointer) / 2)]; //Maybe need to round down 
                    Node comparer;
                    if (Child.Cost < Parent.Cost)
                    {
                        comparer = Child;
                        Heap[pointer] = Heap[Math.Abs((pointer) / 2)];
                        Heap[Math.Abs((pointer) / 2)] = comparer;
                    }
                    pointer = Math.Abs((pointer) / 2);
                    if (pointer == 0) { break; }
                }
            }
        }
        public Node Remove()
        {
            Node Root = Heap[0];
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

                Node Parent = Heap[pointer];
                Node LChild = null;
                Node RChild = null;

                if ((2 * pointer + 1 <= count - 1)) { LChild = Heap[2 * pointer + 1]; }
                if ((2 * pointer + 2 <= count - 1)) { RChild = Heap[2 * pointer + 2]; }
               
                if (LChild == null) { break; }
                if (RChild == null)
                {
                    if (Parent.Cost > LChild.Cost)
                    {
                        SubstituteParentByChild(pointer, (2 * pointer + 1));
                    }
                    break;
                }
                else if (Parent.Cost > LChild.Cost || Parent.Cost > RChild.Cost)
                {
                    if (LChild.Cost < RChild.Cost)
                    {
                        SubstituteParentByChild(pointer, (2 * pointer + 1));
                        pointer = 2 * pointer + 1;
                    }
                    else
                    {
                        SubstituteParentByChild(pointer, (2 * pointer + 2));
                        pointer = 2 * pointer + 2;
                    }
                }
            }
        }
        private void SubstituteParentByChild(int parentIndex, int childIndex)
        {
            Node comparer = Heap[parentIndex];
            Heap[parentIndex] = Heap[childIndex];
            Heap[childIndex] = comparer;
        }
    }
}
