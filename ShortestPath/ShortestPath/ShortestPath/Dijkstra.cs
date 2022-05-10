namespace ShortestPath
{
    public class Dijkstra
    {
        public Dictionary<string, Node> ExtractedNodes = new();
        public Dictionary<string, Node> UpdateNetworkProp(Network network, string destination, IHeap heap)
        {
            string tempDestination = destination;
            network.Nodes[tempDestination].Cost = 0;
            heap.Add(network.Nodes[tempDestination]);
            for (int i = 0; i < network.Nodes.Count; i++)
            {
                List<Arc> backwardArcs = network.NodesBackArcs[tempDestination];
                foreach (Arc arc in backwardArcs)
                {
                    if (network.Nodes[arc.Orig].Cost > network.Nodes[arc.Dest].Cost + arc.Cost)
                    {
                        network.Nodes[arc.Orig].Cost = arc.Cost + network.Nodes[arc.Dest].Cost;
                        network.Nodes[arc.Orig].Successor = arc.Dest;
                        heap.Add(new Node(arc.Orig, arc.Cost + network.Nodes[arc.Dest].Cost));
                    }
                }
                if (!ExtractedNodes.ContainsKey(heap.Root.ID))
                {
                    ExtractedNodes.Add(network.Nodes[heap.Root.ID].ID, network.Nodes[heap.Root.ID]);
                }

                if (ExtractedNodes.Count == network.Nodes.Count)
                    break;

                while (true)
                {
                    var Des = heap.Remove();
                    if (!ExtractedNodes.ContainsKey(Des.ID))
                    {
                        tempDestination = network.Nodes[Des.ID].ID;
                        break;
                    }
                }
            }
            return ExtractedNodes;
        }
    }
}
