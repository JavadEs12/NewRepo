using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShortestPath.Test
{
    [TestClass]
    public class RandomHeapGeneratorTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var heap = new Heap(GetNodes(2));
            Assert.IsNotNull(heap);
        }

        [TestMethod]
        public void AddTest()
        {
            int numberOfElements = 1000;
            var heap = new Heap(GetNodes(numberOfElements));
            Assert.AreEqual(numberOfElements, heap.count);
        } 

        [TestMethod]
        public void RemoveTest()
        {
            int numberOfElements = 1000;
            var nodes = GetNodes(numberOfElements);
            var heap = new Heap(nodes);
            var previousCost = double.NegativeInfinity;

            for (int i = 0; i < numberOfElements-1; i++)
            {
                var removedNode = heap.Remove();
                Assert.IsTrue(removedNode.Cost >= previousCost);
                previousCost = removedNode.Cost;
            }
            Assert.AreEqual(1, heap.count);
        }

        private Dictionary<string, Node> GetNodes(int numberOfElements)
        {
            RandomNodeDictionaryGenerator randomNodeGenerator = new();
            return randomNodeGenerator.Input(numberOfElements);
        }
    }
}
