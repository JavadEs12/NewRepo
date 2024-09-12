namespace ShortestPath
{
    public interface IHeap
    {
        public void Add(Node node);
        public Node Remove();
        public Node Root {get;}
    }
}
