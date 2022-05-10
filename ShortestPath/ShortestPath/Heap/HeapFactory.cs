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
            return heapType switch
            {
                HeapType.ArrayHeap => new ArrayHeap(),
                HeapType.Heap => new Heap(),
                _ => null,
            };
        }
    }
}
