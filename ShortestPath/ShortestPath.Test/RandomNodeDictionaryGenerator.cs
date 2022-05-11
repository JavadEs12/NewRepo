namespace ShortestPath.Test
{
    public class RandomNodeDictionaryGenerator
    {
        public Dictionary<string, Node> Input(int numberOfElements)
        {
            Dictionary<string, Node> _nodes = new();
            Random rnd = new Random(0);
            for (int i = 0; i < numberOfElements; i += 1)
            {
                Node node = new(i.ToString(), rnd.NextDouble());
                _nodes.Add(node.ID, node);
            }
            return _nodes;
        }
    }
}
