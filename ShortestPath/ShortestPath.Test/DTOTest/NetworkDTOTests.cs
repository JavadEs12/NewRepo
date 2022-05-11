using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ShortestPath.Test.DTOTest
{
    [TestClass]
    public class NetworkDTOTests
    {
        [TestMethod]
        public void TestSerialize()
        {
            Node orig = new Node("1", 0);
            Node des = new Node("2", 0);
            Arc arc = new() { Idno = "1", Orig = "1", Dest = "2", Cost = 10 };
            NetworkDTO networkDTO = new() {
                Arcs= new List<Arc> { arc } ,
                Nodes = new List<Node> { orig, des, } 
            };
            var fileName = Path.Combine("DTOTest", "networkDTO.json");
            var serialized = JsonConvert.SerializeObject(networkDTO,Formatting.Indented);
            var expected = File.ReadAllText(fileName);
            
            Assert.AreEqual(expected, serialized);
        }

        [TestMethod]
        public void TestRoundTrip()
        {
            var fileName = Path.Combine("DTOTest", "networkDTO.json");
            
            var expected = File.ReadAllText(fileName);
            var deSerialized = JsonConvert.DeserializeObject<NetworkDTO>(expected);
            var serialized = JsonConvert.SerializeObject(deSerialized, Formatting.Indented);

            Assert.AreEqual(expected, serialized);
        }
    }
}
