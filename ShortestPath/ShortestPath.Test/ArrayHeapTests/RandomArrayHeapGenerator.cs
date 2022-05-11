using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestPath;

namespace ShortestPath.Test.ArrayHeapTests
{
    [TestClass]
    public class RandomArrayHeapGenerator
    {
        int NumberOfElements = 1000;
        readonly Dictionary<string, Node> _nodes = new();

        public void Input()
        {
            Random rnd = new Random(0);
            for (int i = 0; i < NumberOfElements; i += 1)
            {
                Node node = new(i.ToString(), rnd.NextDouble());
                _nodes.Add(node.ID,node);
            }
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Input();
            var arrayHeap = new ArrayHeap(_nodes);
            Assert.IsNotNull(arrayHeap);

        }
        [TestMethod]
        public void AddTest()
        {

            Input();
            var arrayHeap = new ArrayHeap(_nodes);
            Assert.AreEqual(NumberOfElements, arrayHeap.count);
        }
        [TestMethod]
        public void RemoveTest()
        {
            Input();
            var arrayHeap = new ArrayHeap(_nodes);
            int i = 0;
            foreach (KeyValuePair<string,Node> item in _nodes)
            {
                arrayHeap.Remove();
                NumberOfElements--;
            }
            Assert.AreEqual(NumberOfElements, arrayHeap.count);
        }
    }
}
