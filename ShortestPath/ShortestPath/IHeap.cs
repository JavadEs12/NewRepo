using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public interface IHeap
    {
        public void Add(Node node);
        public Node Remove();
        public Node Root {get;}
    }
}
