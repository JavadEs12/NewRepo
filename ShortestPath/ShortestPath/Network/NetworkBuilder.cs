namespace ShortestPath
{
    public class NetworkBuilder
    {
        private Dictionary<string, Arc> _arcs = new Dictionary<string, Arc>();
        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private Dictionary<string, List<Arc>> _nodesBackArcs = new Dictionary<string, List<Arc>>();

        public Network BuildNetwork(List<Arc> arcs)
        {
            AssignArcs(arcs);
            return new Network(_arcs, _nodes, _nodesBackArcs);
        }

        private void AssignArcs(List<Arc> arcs)
        {
            foreach (Arc arc in arcs)
            {
                _arcs.Add(arc.Idno, arc);
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
            if (!_nodes.ContainsKey(arc.Orig)) { InitializeNodes(arc.Orig); }
            if (!_nodes.ContainsKey(arc.Dest)) { InitializeNodes(arc.Dest); }
        }

        private void InitializeNodes(string tempNode)
        {
            Node node = new Node(tempNode, double.PositiveInfinity, " ");
            _nodes.Add(tempNode, node);
        }

        private void AssignNodesBackwardArcs(Arc arc)
        {
            if (!_nodesBackArcs.ContainsKey(arc.Dest))
            {
                List<Arc> list = new List<Arc>() { arc };
                _nodesBackArcs.Add(arc.Dest, list);
            }
            else
            {
                _nodesBackArcs[arc.Dest].Add(arc);
            }
        }
    }
}
