namespace ShortestPath
{
    public class Search
    {
        public void ShortestPath(Network network)
        {
            try
            {
                UpdateNodesProperties(network);
                List<string> ShortestPath = new List<string>();
                ShortestPath.Add(Program.Origin);
                string InitialNode = Program.Origin;

                while (true)
                {
                    var FollowingNode = network.ExtractedNodes[InitialNode].Successor;
                    InitialNode = FollowingNode;
                    ShortestPath.Add(FollowingNode);
                    if (InitialNode == Program.Destination) { break; }
                }
                Print(ShortestPath);
            }
            catch
            {
                throw new Exception("There is no path between the given Origin - Destination");
            }
        }

        public void UpdateNodesProperties(Network network)
        {
            string tempDestination = Program.Destination;
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

