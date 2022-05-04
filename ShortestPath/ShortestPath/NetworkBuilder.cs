namespace ShortestPath
{
    public class NetworkBuilder
    {
        public void BuildNetwork(Network network, List<Arc> arcs)
        {
            AssignArcs(network, arcs);
        }

        private void AssignArcs(Network network, List<Arc> arcs)
        {
            foreach (Arc arc in arcs)
            {
                network.NetworkArcs.Add(arc.Idno, arc);
                AssignNodes(network, arc);
            }
        }

        private void AssignNodes(Network network, Arc arc)
        {
            ExtractNodes(network, arc);
            AssignNodesBackwardArcs(network, arc);
        }

        private void ExtractNodes(Network network, Arc arc)
        {
            if (!network.NetworkNodes.ContainsKey(arc.Orig)) { InitializeNodes(network, arc.Orig); }
            if (!network.NetworkNodes.ContainsKey(arc.Dest)) { InitializeNodes(network, arc.Dest); }
        }

        private void InitializeNodes(Network network, string tempNode)
        {
            Node node = new Node(tempNode, double.PositiveInfinity, " ");
            network.NetworkNodes.Add(tempNode, node);
        }

        private void AssignNodesBackwardArcs(Network network, Arc arc)
        {
            if (!network.NetworkNodesBackArcs.ContainsKey(arc.Dest))
            {
                List<Arc> list = new List<Arc>() { arc };
                network.NetworkNodesBackArcs.Add(arc.Dest, list);
            }
            else
            {
                network.NetworkNodesBackArcs[arc.Dest].Add(arc);
            }
        }
    }
}
