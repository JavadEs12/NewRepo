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
                AddNewNode(node.Value);
            }
        }
        public void AddNewNode(Node node)
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
                    if (Child.Cost > Parent.Cost)
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
        public void RemoveRoot()
        {
            Node Root = Heap[0];
            Heap[0] = Heap[count - 1];
            count--;
            PerculateDown();
        }

        private void PerculateDown()
        {
            int pointer = 0;
            while (true)
            {
                Node Parent = Heap[pointer];
                Node LChild = Heap[2 * pointer + 1];
                Node RChild = Heap[2 * pointer + 2];

                if (LChild.Cost > RChild.Cost)
                {
                    SubstituteParentByChild(pointer,(2 * pointer + 2));
                    pointer = 2 * pointer + 2;
                }
                else
                {
                    SubstituteParentByChild(pointer, (2 * pointer + 1));
                    pointer = 2 * pointer + 1;
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
