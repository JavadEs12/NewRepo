using Newtonsoft.Json;
namespace ShortestPath
{
    public class JsonDeserializer : IDeserializer
    {
        public List<Arc> Deserialize(string text)
        {
            var deserialized = JsonConvert.DeserializeObject<List<Arc>>(text);
            if (deserialized == null)
            {
                throw new Exception();
            }
            return deserialized;
        }
    }
}
