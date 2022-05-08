namespace ShortestPath
{
    public class NetworkBuilder
    {
        private readonly Dictionary<string, Arc> _arcs = new();
        private readonly Dictionary<string, Node> _nodes = new();
        private readonly Dictionary<string, List<Arc>> _nodesBackArcs = new();
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
        private void InitializeNodes(string tempNode) => _nodes
            .Add(tempNode, new Node(tempNode, double.PositiveInfinity, " "));

        private void AssignNodesBackwardArcs(Arc arc)
        {
            if (!_nodesBackArcs.ContainsKey(arc.Dest))
            {
                List<Arc> list = new() { arc };
                _nodesBackArcs.Add(arc.Dest, list);
            }
            else
                _nodesBackArcs[arc.Dest].Add(arc);
        }
    }
}
