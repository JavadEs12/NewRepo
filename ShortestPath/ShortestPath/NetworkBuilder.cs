using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public class NetworkBuilder
    {
        public void Network_Building(Network network, List<Arc> arcs)
        {
            Arc_Assigning(network, arcs);
            HeapBuilding(network);
        }

        private void Arc_Assigning(Network network, List<Arc> arcs)
        {
            foreach (Arc arc in arcs)
            {
                network.NetworkArcs.Add(arc.Idno, arc);
                Nodes_Assigning(network, arc);
            }
        }

        private void Nodes_Assigning(Network network, Arc arc)
        {
            Node_Extraction(network, arc);
            Network_NodesBackArcs_Assingment(network, arc);
        }

        private void Node_Extraction(Network network, Arc arc)
        {
            if (!network.NetworkNodes.ContainsKey(arc.Orig)) { NodesInitializing(network, arc.Orig); }
            if (!network.NetworkNodes.ContainsKey(arc.Dest)) { NodesInitializing(network, arc.Dest); }
        }

        private void NodesInitializing(Network network, string tempNode)
        {
            Node node = new Node(tempNode, double.PositiveInfinity, " ");
            network.NetworkNodes.Add(tempNode, node);
        }

        private void Network_NodesBackArcs_Assingment(Network network, Arc arc)
        {
            if (!network.NetworkNodesBackArcs.ContainsKey(arc.Dest))
            {
                List<Arc> list = new List<Arc>() { arc };
                network.NetworkNodesBackArcs.Add(arc.Dest, list);
            }
            else
            {
                network.NetworkNodesBackArcs[arc.Dest].Add(arc);
            }
        }

        private void HeapBuilding(Network network)
        {
            network.heap = new HeapBuilder(network.NetworkNodes);
        }
    }
}
