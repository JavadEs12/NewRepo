﻿namespace ShortestPath
{
    public class ShortestPath
    {
        public IHeap? heap;
        public ShortestPath(HeapFactory factory)
        {
            heap = factory.GetHeap();
        }
        public List<string>? FindShortestPath(Network network,
                                              string origin,
                                              string destination)
        {
            try
            {
                InitializeHeap(network);
                Dijkstra dijkstra = new();
                Dictionary<string,Node>? ExtractedNodes = dijkstra
                    .UpdateNetworkProp(network, destination, heap);
                List<string> ShortestPath = new();
                ShortestPath.Add(origin);
                string? InitialNode = origin;

                while (true)
                {
                    string? FollowingNode = ExtractedNodes[InitialNode].Successor;
                    InitialNode = FollowingNode;
                    ShortestPath.Add(FollowingNode);
                    if (InitialNode == destination)
                        break;
                }
                return ShortestPath;
            }
            catch
            {
                Console.WriteLine("There is no path between the given Origin - Destination");
                return null;
            }
        }
        private void InitializeHeap(Network network)
        {
            heap = new Heap(network.Nodes);
        }
    }
}

