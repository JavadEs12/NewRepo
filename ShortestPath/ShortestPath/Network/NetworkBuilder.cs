namespace ShortestPath
{
    public class NetworkBuilder
    {
        private Dictionary<string, Arc> _NetworkArcs = new Dictionary<string, Arc>();
        private Dictionary<string, Node> _NetworkNodes = new Dictionary<string, Node>();
        private Dictionary<string, List<Arc>> _NetworkNodesBackArcs = new Dictionary<string, List<Arc>>();

        public Network BuildNetwork(List<Arc> arcs)
        {
            AssignNetwork(arcs);
            return new Network(_NetworkArcs, _NetworkNodes, _NetworkNodesBackArcs);
        }

        private void AssignNetwork(List<Arc> arcs)
        {
            AssignArcs(arcs);
        }

        private void AssignArcs(List<Arc> arcs)
        {
            foreach (Arc arc in arcs)
            {
                _NetworkArcs.Add(arc.Idno, arc);
                AssignNodes(arc);
            }
        }

        private void AssignNodes(Arc arc)
        {
            ExtractNodes(arc);
            AssignNodesBackwardArcs(arc);
        }

        private void ExtractNodes(Arc arc)
        {
            if (!_NetworkNodes.ContainsKey(arc.Orig)) { InitializeNodes(arc.Orig); }
            if (!_NetworkNodes.ContainsKey(arc.Dest)) { InitializeNodes(arc.Dest); }
        }

        private void InitializeNodes(string tempNode)
        {
            Node node = new Node(tempNode, double.PositiveInfinity, " ");
            _NetworkNodes.Add(tempNode, node);
        }

        private void AssignNodesBackwardArcs(Arc arc)
        {
            if (!_NetworkNodesBackArcs.ContainsKey(arc.Dest))
            {
                List<Arc> list = new List<Arc>() { arc };
                _NetworkNodesBackArcs.Add(arc.Dest, list);
            }
            else
            {
                _NetworkNodesBackArcs[arc.Dest].Add(arc);
            }
        }
    }
}
