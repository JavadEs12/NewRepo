using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public class HeapFactory
    {
        public enum HeapType
        {
            Heap,
            ArrayHeap
        }
        private HeapType heapType;

        public HeapFactory(HeapType type)
        {
            heapType = type;
        }

        public IHeap GetHeap()
        {
            switch (heapType)
            {
                case HeapType.ArrayHeap: return new ArrayHeap();
                case HeapType.Heap: return new Heap();
                default: return null;
            }
        }
    }
}
