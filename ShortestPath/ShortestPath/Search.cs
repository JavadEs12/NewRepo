namespace ShortestPath
{
    public class Search
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string MainDestination { get; set; }

        Dictionary<string, Node> ExtractedNodes = new Dictionary<string, Node>();
        Heap heap = new Heap();
        public void HeapInitialization(Node node1)
        {
            heap = new Heap(node1.NetworkNodes);
        }

        public void UpdateNodesProperties(Node node1, Arc arc1)
        {
            HeapInitialization(node1);
            node1.NetworkNodes[Destination].Cost = 0;
            heap.Add(node1.NetworkNodes[Destination]);
            for (int i = 0; i < node1.NetworkNodes.Count; i++)
            {
                List<Arc> backwardArcs = arc1.BackArcs[Destination];
                foreach (Arc arc in backwardArcs)
                {
                    if (!(node1.NetworkNodes[arc.Orig].Cost <= node1.NetworkNodes[arc.Dest].Cost + arc.Cost))
                    {
                        node1.NetworkNodes[arc.Orig].Cost = arc.Cost + node1.NetworkNodes[arc.Dest].Cost;
                        node1.NetworkNodes[arc.Orig].Successor = arc.Dest;
                        Node node = new Node(arc.Orig, arc.Cost + node1.NetworkNodes[arc.Dest].Cost);
                        heap.Add(node);
                    }
                }
                if (!ExtractedNodes.ContainsKey(heap.root.ID))
                {
                    ExtractedNodes.Add(node1.NetworkNodes[heap.root.ID].ID, node1.NetworkNodes[heap.root.ID]);
                }

                if (ExtractedNodes.Count == node1.NetworkNodes.Count) { break; }
                while (true)
                {
                    Node des = heap.Remove();
                    if (!ExtractedNodes.ContainsKey(des.ID))
                    {
                        Destination = node1.NetworkNodes[des.ID].ID;
                        break;
                    }
                }
            }
        }
        public void ShortestPath(Node node1, Arc arc1)
        {
            try
            {
                UpdateNodesProperties(node1, arc1);
                List<string> ShortestPath = new List<string>();
                ShortestPath.Add(Origin);

                while (true)
                {
                    var FollowingNode = ExtractedNodes[Origin].Successor;
                    Origin = FollowingNode;
                    ShortestPath.Add(FollowingNode);
                    if (Origin == MainDestination) { break; }
                }

                Console.WriteLine($"Sequence of shortest path elements are as:");
                foreach (string node in ShortestPath)
                {
                    Console.WriteLine(node);
                }
            }
            catch
            {
                throw new Exception("There is no path between the given Origin - Destination");
            }

        }
    }
}