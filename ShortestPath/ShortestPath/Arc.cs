namespace ShortestPath
{
    public class Arc
    {
        public string Idno { get; set; }
        public string Orig { get; set; }
        public string Dest { get; set; }
        public double Cost { get; set; }

        public static List<Arc> arcs = new List<Arc>();
        public static Dictionary<string, List<Arc>> BackArcs = new Dictionary<string, List<Arc>>();

        public void NodeAssignment()
        {
            foreach (Arc arc in arcs)
            {
                if (!Node.NetworkNodes.ContainsKey(arc.Orig)) { NodesInitialization(arc.Orig); }
                if (!Node.NetworkNodes.ContainsKey(arc.Dest)) { NodesInitialization(arc.Dest); }

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


        public static Node NodesInitialization(string orig)
        {
            Node node = new Node(orig, double.PositiveInfinity, " ");
            Node.NetworkNodes.Add(orig, node);
            return node;
        }
    }
}
