using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShortestPath.Test
{
    [TestClass]
    public class HeapNodeTest
    {
        Dictionary<string, double> properties = new Dictionary<string, double>()
        {
            {"A",10},{"B",11},{"C",12.5},{"D",13.95}
        };
        Dictionary<string, HeapNode> heapNodes = new Dictionary<string, HeapNode>();

        [TestMethod]
        public void ConstructorTest()
        {
            foreach (KeyValuePair<string, double> item in properties)
            {
                HeapNode heapNode = new HeapNode(item.Key, item.Value);
                heapNodes.Add(item.Key, heapNode);
            }
            Assert.AreEqual(4, heapNodes.Count);
            Assert.AreEqual(12.5, heapNodes["C"].Cost);
            Assert.AreEqual(13.95, heapNodes["D"].Cost);
        }

        [TestMethod]
        public void ParentConstructorTest()
        {
            HeapNode E = new HeapNode("F", 20);
            HeapNode F = new HeapNode(E);

            Assert.AreEqual(F.Parent, E);
        }
    }
}
