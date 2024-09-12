using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ShortestPath.Test
{
    [TestClass]
    public class ArrayHeapTest
    {
        readonly Dictionary<string, Node> nodes = new();
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
            var heap = new ArrayHeap(nodes);
            Assert.IsNotNull(heap.heap);
        }
        [TestMethod]
        public void AddTest()
        {

            Input();
            var heap = new ArrayHeap(nodes);
            var node = heap.heap[0];
            Assert.AreEqual(2, node.Cost);
        }
        [TestMethod]
        public void RemoveTest()
        {
            Input();
            var heap = new ArrayHeap(nodes);
            var Root = heap.Remove();
            Assert.AreEqual(2, Root.Cost);
            var Root1 = heap.Remove();
            Assert.AreEqual(10, Root1.Cost);
        }
    }
}
