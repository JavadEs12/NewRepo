using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public class Network
    {
        public Dictionary<string,Arc> NetworkArcs = new Dictionary<string, Arc>();
        public Dictionary<string, Node> NetworkNodes = new Dictionary<string, Node>();
        public Dictionary<string, List<Arc>> NetworkNodesBackArcs = new Dictionary<string, List<Arc>>();  
        public Dictionary<string, Node> ExtractedNodes = new Dictionary<string, Node>();
        public Heap heap = new Heap();
    }
}
