namespace ShortestPath.Test
{
    public class RandomNodeDictionaryGenerator
    {
        public static Dictionary<string, Node>? GenerateNodes(int numberOfElements)
        {
            Dictionary<string, Node>? _nodes = new();
            Random rnd = new(0);
            for (int i = 0; i < numberOfElements; i += 1)
            {
                Node node = new(i.ToString(), rnd.NextDouble());
                _nodes.Add(node.ID, node);
            }
            return _nodes;
        }
    }
}
