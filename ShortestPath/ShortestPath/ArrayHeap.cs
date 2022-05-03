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
        private Node Pointer;
        private Node Child;
        private Node Parent;
        private int count;

        public ArrayHeap(Dictionary<string,Node> nodes)
        {
            count = 0;
            foreach (KeyValuePair<string,Node> node in nodes)
            {
                AddNewNode(node.Value);
            }
        }
        public void AddNewNode(Node node)
        {
            Heap.Add(node);
            count++;    
            perculateUp();
        }

        private void perculateUp()
        {
            if(Heap.Count == 0) { return; }
            
            else
            {
                
            }
            
        }
    }
}
