namespace ShortestPath
{
    public class DijkstraAlgorithm
    {
        public void FindShortestPath(Network network, string origin, string destination)
        {
            try
            {
                UpdateNodesProperties(network, destination);
                List<string> ShortestPath = new List<string>();
                ShortestPath.Add(origin);
                string InitialNode = origin;

                while (true)
                {
                    var FollowingNode = network.ExtractedNodes[InitialNode].Successor;
                    InitialNode = FollowingNode;
                    ShortestPath.Add(FollowingNode);
                    if (InitialNode == destination) { break; }
                }
                Print(ShortestPath);
            }
            catch
            {
                throw new Exception("There is no path between the given Origin - Destination");
            }
        }

        public void UpdateNodesProperties(Network network, string destination)
        {
            string tempDestination = destination;
            network.NetworkNodes[tempDestination].Cost = 0;
            network.heap.Add(network.NetworkNodes[tempDestination]);
            for (int i = 0; i < network.NetworkNodes.Count; i++)
            {
                List<Arc> backwardArcs = network.NetworkNodesBackArcs[tempDestination];
                foreach (Arc arc in backwardArcs)
                {
                    if (!(network.NetworkNodes[arc.Orig].Cost <= network.NetworkNodes[arc.Dest].Cost + arc.Cost))
                    {
                        network.NetworkNodes[arc.Orig].Cost = arc.Cost + network.NetworkNodes[arc.Dest].Cost;
                        network.NetworkNodes[arc.Orig].Successor = arc.Dest;
                        Node node = new Node(arc.Orig, arc.Cost + network.NetworkNodes[arc.Dest].Cost);
                        network.heap.Add(node);
                    }
                }
                if (!network.ExtractedNodes.ContainsKey(network.heap.root.ID))
                {
                    network.ExtractedNodes.Add(network.NetworkNodes[network.heap.root.ID].ID, network.NetworkNodes[network.heap.root.ID]);
                }

                if (network.ExtractedNodes.Count == network.NetworkNodes.Count) { break; }
                while (true)
                {
                    Node Des = network.heap.Remove();
                    if (!network.ExtractedNodes.ContainsKey(Des.ID))
                    {
                        tempDestination = network.NetworkNodes[Des.ID].ID;
                        break;
                    }
                }
            }
        }

        private void Print(List<string> shortestPath)
        {
            Console.WriteLine($"Sequence of shortest path elements are as:");
            foreach (string node in shortestPath)
            {
                Console.WriteLine(node);
            }

        }
    }
}

