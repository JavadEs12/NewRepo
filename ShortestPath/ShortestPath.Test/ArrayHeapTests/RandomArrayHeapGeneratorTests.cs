using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShortestPath.Test.ArrayHeapTests
{
    [TestClass]
    public class RandomArrayHeapGeneratorTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var numberOfElements = 1000;
            ArrayHeap? arrayHeap = new(RandomNodeDictionaryGenerator.GenerateNodes(numberOfElements));
            Assert.IsNotNull(arrayHeap);
            Assert.AreEqual(numberOfElements,arrayHeap.heap.Count);
        }

        [TestMethod]
        public void AddTest()
        {
            int numberOfElements = 1000;
            Dictionary<string,Node>? nodes = RandomNodeDictionaryGenerator.GenerateNodes(numberOfElements);
            ArrayHeap? arrayHeap = new();
            foreach (KeyValuePair<string,Node> node in nodes)
            {
                arrayHeap.Add(node.Value);
                var root= arrayHeap.Root;
                Assert.IsTrue(arrayHeap.heap.Any(x => x.Cost >= root.Cost));
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            int numberOfElements = 10000;
            var nodes = RandomNodeDictionaryGenerator.GenerateNodes(numberOfElements);
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
    }
}
