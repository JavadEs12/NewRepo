using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath.Test
{
    [TestClass]
    public class RandomHeapGenerator
    {
        readonly Dictionary<string, Node> _nodes = new();
        RandomHeapGeneration _rndHeap = new();

        public RandomHeapGenerator()
        {
            RandomHeapGeneration _rndHeap = new();
            Dictionary<string, Node> nodes = _rndHeap.Input();
            _nodes = nodes;
        }

        [TestMethod]
        public void ConstructorTest()
        {
            var arrayHeap = new ArrayHeap(_nodes);
            Assert.IsNotNull(arrayHeap);

        }
        [TestMethod]
        public void AddTest()
        {

            var arrayHeap = new ArrayHeap(_nodes);
            Assert.AreEqual(_rndHeap.NumberOfElements, arrayHeap.count);
        }
        [TestMethod]
        public void RemoveTest()
        {
            var arrayHeap = new ArrayHeap(_nodes);
            int i = 0;
            foreach (KeyValuePair<string, Node> item in _nodes)
            {
                arrayHeap.Remove();
                _rndHeap.NumberOfElements--;
            }
            Assert.AreEqual(_rndHeap.NumberOfElements, arrayHeap.count);
        }
    }
}
