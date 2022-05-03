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
        public ArrayList Heap = new ArrayList();
        private Node Root;
        private Node Child;
        private Node Parent;
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
                    Child = (Node)Heap[pointer];
                    Parent = (Node)Heap[Math.Abs((pointer) / 2)]; //Maybe need to round down 
                    Node comparer;
                    if (Child.Cost <= Parent.Cost)
                    {
                        comparer = Child;
                        Heap[pointer] = Heap[Math.Abs((pointer) / 2)];
                        Heap[Math.Abs((pointer) / 2)] = comparer;
                    }
                    pointer = Math.Abs((pointer) / 2);
                    if(pointer == 0) { break; }
                }
            }

        }
    }
}
