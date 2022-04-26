namespace ShortestPath
{
    public class Search
    {
        public static string Origin;
        public static string Destination;
        public static string MainDestination;
        Dictionary<string, Node> ExtractedNodes = new Dictionary<string, Node>();
        Heap heap;
        public void HeapInitialization()
        {
            heap = new Heap(Node.NetworkNodes);
        }

        public void UpdateNodesProperties()
        {
            HeapInitialization();
            Node.NetworkNodes[Destination].Cost = 0;
            Heap.Add(Node.NetworkNodes[Destination]);
            for (int i = 0; i < Node.NetworkNodes.Count; i++)
            {
                List<Arc> backwardArcs = Arc.BackArcs[Destination];
                foreach (Arc arc in backwardArcs)
                {
                    if (!(Node.NetworkNodes[arc.Orig].Cost <= Node.NetworkNodes[arc.Dest].Cost + arc.Cost))
                    {
                        Node.NetworkNodes[arc.Orig].Cost = arc.Cost + Node.NetworkNodes[arc.Dest].Cost;
                        Node.NetworkNodes[arc.Orig].Successor = arc.Dest;
                        Node node = new Node(arc.Orig, arc.Cost + Node.NetworkNodes[arc.Dest].Cost);
                        Heap.Add(node);
                    }
                }
                if (!ExtractedNodes.ContainsKey(Heap.root.ID))
                {
                    ExtractedNodes.Add(Node.NetworkNodes[Heap.root.ID].ID, Node.NetworkNodes[Heap.root.ID]);
                }

                if (ExtractedNodes.Count == Node.NetworkNodes.Count) { break; }
                while (true)
                {
                    Node des = Heap.Remove();
                    if (!ExtractedNodes.ContainsKey(des.ID))
                    {
                        Destination = Node.NetworkNodes[des.ID].ID;
                        break;
                    }
                }
            }
        }
        public void ShortestPath()
        {
            try
            {
                UpdateNodesProperties();
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

