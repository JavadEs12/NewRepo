using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
namespace ShortestPath.Test
{
    [TestClass]
    public class ArrayHeapTest
    {
        Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        private void Input()
        {
            nodes.Add("1", new Node("1", 11, "a"));
            nodes.Add("2", new Node("2", 10, "b"));
            nodes.Add("3", new Node("3", 2, "c"));
            nodes.Add("4", new Node("4", 14, "d"));
        }

        [TestMethod]
        public void ArrayHeaptest()
        {
            Input();
            ArrayHeap heap = new ArrayHeap(nodes);
            Assert.IsNotNull(heap.Heap);
        }
        [TestMethod]
        public void AddTest()
        {

            Input();
            ArrayHeap heap = new ArrayHeap(nodes);
            Node node = heap.Heap[0];
            Assert.AreEqual(2, node.Cost);
        }
        [TestMethod]
        public void RemoveRootTest()
        {
            Input();
            ArrayHeap heap = new ArrayHeap(nodes);
            Node Root = heap.RemoveRoot();
            Assert.AreEqual(2, Root.Cost);
            Node Root1 = heap.RemoveRoot();
            Assert.AreEqual(10, Root1.Cost);
        }
    }
}
