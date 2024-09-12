namespace ShortestPath
{
    public class Network
    {
        public Dictionary<string, Arc> Arcs = new();
        public Dictionary<string, Node> Nodes = new();
        public Dictionary<string, List<Arc>> NodesBackArcs = new();
        public Network(Dictionary<string, Arc> arcs, Dictionary<string, Node> nodes,
                       Dictionary<string, List<Arc>> nodesBackArcs)
        {
            Arcs = arcs;
            Nodes = nodes;
            NodesBackArcs = nodesBackArcs;
        }
    }
}
