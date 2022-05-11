using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath.Test
{
    public class RandomHeapGeneration
    {
        public int NumberOfElements = 1000;
        readonly Dictionary<string, Node> _nodes = new();

        public Dictionary<string, Node> Input()
        {
            Random rnd = new Random(0);
            for (int i = 0; i < NumberOfElements; i += 1)
            {
                Node node = new(i.ToString(), rnd.NextDouble());
                _nodes.Add(node.ID, node);
            }
            return _nodes;
        }
    }
}
