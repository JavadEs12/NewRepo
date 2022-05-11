using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShortestPath.Test.ArrayHeapTests
{
    [TestClass]
    public class RandomArrayHeapGeneratorTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var arrayHeap = new ArrayHeap(GetNodes(2));
            Assert.IsNotNull(arrayHeap);
        }

        [TestMethod]
        public void AddTest()
        {
            int numberOfElements = 1000;
            var arrayHeap = new ArrayHeap(GetNodes(numberOfElements));
            Assert.AreEqual(numberOfElements, arrayHeap.count);
        }

        [TestMethod]
        public void RemoveTest()
        {
            int numberOfElements = 10000;
            var nodes = GetNodes(numberOfElements);
            var arrayHeap = new ArrayHeap(nodes);
            var previousCost = double.NegativeInfinity;

            for (int i = 0; i < numberOfElements; i++)
            {
                var removedNode = arrayHeap.Remove();
                Assert.IsTrue(removedNode.Cost >= previousCost,$"{i} {removedNode.Cost} {previousCost}");
                previousCost = removedNode.Cost;
            }
            Assert.AreEqual(0, arrayHeap.count);
        }

        private Dictionary<string, Node> GetNodes(int numberOfElements)
        {
            RandomNodeDictionaryGenerator randomNodeGenerator = new();
            return randomNodeGenerator.Input(numberOfElements);
        }
    }
}
