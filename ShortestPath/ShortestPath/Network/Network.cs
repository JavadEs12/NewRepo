namespace ShortestPath
{
    public class Network
    {
        public Dictionary<string, Arc> Arcs = new Dictionary<string, Arc>();
        public Dictionary<string, Node> Nodes = new Dictionary<string, Node>();
        public Dictionary<string, List<Arc>> NodesBackArcs = new Dictionary<string, List<Arc>>();

        public Network(Dictionary<string, Arc> arcs,
            Dictionary<string, Node> nodes,
            Dictionary<string, List<Arc>> nodesBackArcs
            )
        {
            Arcs = arcs;
            Nodes = nodes;
            NodesBackArcs = nodesBackArcs;
        }
    }
}
