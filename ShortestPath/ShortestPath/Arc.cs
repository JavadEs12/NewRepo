namespace ShortestPath
{
    public class Arc
    {
        public string Idno { get; set; }
        public string Orig { get; set; }
        public string Dest { get; set; }
        public double Cost { get; set; }

        public List<Arc> arcs { get; set; }
        public Dictionary<string, List<Arc>> BackArcs = new Dictionary<string, List<Arc>>();

        public Arc()
        {

        }

        public void NodeAssignment(Node obj4)
        {
            foreach (Arc arc in arcs)
            {
                if (!obj4.NetworkNodes.ContainsKey(arc.Orig)) { NodesInitialization(obj4, arc.Orig); }
                if (!obj4.NetworkNodes.ContainsKey(arc.Dest)) { NodesInitialization(obj4, arc.Dest); }

                if (!BackArcs.ContainsKey(arc.Dest))
                {
                    List<Arc> list = new List<Arc>() { arc };
                    BackArcs.Add(arc.Dest, list);
                }
                else
                {
                    BackArcs[arc.Dest].Add(arc);
                }
            }
        }

        public static Node NodesInitialization(Node obj4, string orig)
        {
            Node node = new Node(orig, double.PositiveInfinity, " ");
            obj4.NetworkNodes.Add(orig, node);
            return node;
        }
    }
}
