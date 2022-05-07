using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShortestPath.Test
{
    [TestClass]
    public class HeapTest
    {
        Dictionary<string, Node> nodes = new();
        public void Input()
        {
            nodes.Add("1", new Node("1", 11, "a"));
            nodes.Add("2", new Node("2", 10, "b"));
            nodes.Add("3", new Node("3", 2, "c"));
            nodes.Add("4", new Node("4", 14, "d"));
        }
        [TestMethod]
        public void Heap_Constructor_Test()
        {
            Input();
            var heap = new Heap(nodes);
            Assert.IsNotNull(heap);
        }
        [TestMethod]
        public void Heap_Add_Test()
        {
            Input();
            var heap = new Heap(nodes);
            Assert.AreEqual("3", heap.root.ID);
            Assert.AreEqual(2, heap.root.Cost);

        }
        [TestMethod]
        public void Heap_Remove_Test()
        {
            Input();
            var heap = new Heap(nodes);
            heap.Remove();
            Assert.AreEqual("2", heap.root.ID);
        }

    }
}
