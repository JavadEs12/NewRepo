namespace ShortestPath
{
    public class DijkstraByNodeHeap
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string MainDestination { get; set; }

        Dictionary<string, Node> ExtractedNodes = new Dictionary<string, Node>();
        NodeHeap heap = new NodeHeap();
        public void HeapInitialization(Node Obj4)
        {
            heap = new NodeHeap(Obj4.NetworkNodes);
        }

        public void UpdateNodesProperties(Node obj4, Arc obj)
        {
            HeapInitialization(obj4);
            obj4.NetworkNodes[Destination].Cost = 0;
            heap.Add(obj4.NetworkNodes[Destination]);
            for (int i = 0; i < obj4.NetworkNodes.Count; i++)
            {
                List<Arc> backwardArcs = obj.BackArcs[Destination];
                foreach (Arc arc in backwardArcs)
                {
                    if (!(obj4.NetworkNodes[arc.Orig].Cost <= obj4.NetworkNodes[arc.Dest].Cost + arc.Cost))
                    {
                        obj4.NetworkNodes[arc.Orig].Cost = arc.Cost + obj4.NetworkNodes[arc.Dest].Cost;
                        obj4.NetworkNodes[arc.Orig].Successor = arc.Dest;
                        Node node = new Node(arc.Orig, arc.Cost + obj4.NetworkNodes[arc.Dest].Cost);
                        heap.Add(node);
                    }
                }
                if (!ExtractedNodes.ContainsKey(heap.root.ID))
                {
                    ExtractedNodes.Add(obj4.NetworkNodes[heap.root.ID].ID, obj4.NetworkNodes[heap.root.ID]);
                }

                if (ExtractedNodes.Count == obj4.NetworkNodes.Count) { break; }
                while (true)
                {
                    Node des = heap.Remove();
                    if (!ExtractedNodes.ContainsKey(des.ID))
                    {
                        Destination = obj4.NetworkNodes[des.ID].ID;
                        break;
                    }
                }
            }
        }
        public void ShortestPath(Node obj4, Arc obj)
        {
            try
            {
                UpdateNodesProperties(obj4, obj);
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

