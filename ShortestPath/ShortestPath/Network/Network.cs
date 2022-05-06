namespace ShortestPath
{
    public class Network
    {
        public Dictionary<string, Arc> NetworkArcs = new Dictionary<string, Arc>();
        public Dictionary<string, Node> NetworkNodes = new Dictionary<string, Node>();
        public Dictionary<string, List<Arc>> NetworkNodesBackArcs = new Dictionary<string, List<Arc>>();

        public Network(Dictionary<string, Arc> networkArcs,
            Dictionary<string, Node> ntworkNodes,
            Dictionary<string, List<Arc>> networkNodesBackArcs
            )
        {
            NetworkArcs = networkArcs;
            NetworkNodes = ntworkNodes;
            NetworkNodesBackArcs = networkNodesBackArcs;
        }
    }
}
