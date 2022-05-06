namespace ShortestPath
{
    public class DijkstraAlgorithm
    {
        public Dictionary<string, Node> ExtractedNodes = new Dictionary<string, Node>();
        public IHeap heap;

        public DijkstraAlgorithm(HeapFactory factory)
        {
            heap = factory.GetHeap();
        }

        public void FindShortestPath(Network network, string origin, string destination)
        {
            try
            {
                InitializeHeap(network);
                UpdateNodesProperties(network, destination);
                List<string> ShortestPath = new List<string>();
                ShortestPath.Add(origin);
                string InitialNode = origin;

                while (true)
                {
                    var FollowingNode = ExtractedNodes[InitialNode].Successor;
                    InitialNode = FollowingNode;
                    ShortestPath.Add(FollowingNode);
                    if (InitialNode == destination) { break; }
                }
                Print(ShortestPath);
            }
            catch
            {
                Console.WriteLine("There is no path between the given Origin - Destination");
            }
        }

        private void InitializeHeap(Network network)
        {
            heap = new Heap(network.Nodes);
        }

        public void UpdateNodesProperties(Network network, string destination)
        {
            string tempDestination = destination;
            network.Nodes[tempDestination].Cost = 0;
            heap.Add(network.Nodes[tempDestination]);
            for (int i = 0; i < network.Nodes.Count; i++)
            {
                List<Arc> backwardArcs = network.NodesBackArcs[tempDestination];
                foreach (Arc arc in backwardArcs)
                {
                    if (!(network.Nodes[arc.Orig].Cost <= network.Nodes[arc.Dest].Cost + arc.Cost))
                    {
                        network.Nodes[arc.Orig].Cost = arc.Cost + network.Nodes[arc.Dest].Cost;
                        network.Nodes[arc.Orig].Successor = arc.Dest;
                        Node node = new Node(arc.Orig, arc.Cost + network.Nodes[arc.Dest].Cost);
                        heap.Add(node);
                    }
                }
                if (!ExtractedNodes.ContainsKey(heap.Root.ID))
                {
                    ExtractedNodes.Add(network.Nodes[heap.Root.ID].ID, network.Nodes[heap.Root.ID]);
                }

                if (ExtractedNodes.Count == network.Nodes.Count) { break; }
                while (true)
                {
                    Node Des = heap.Remove();
                    if (!ExtractedNodes.ContainsKey(Des.ID))
                    {
                        tempDestination = network.Nodes[Des.ID].ID;
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

