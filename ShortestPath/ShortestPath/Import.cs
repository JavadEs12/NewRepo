using Newtonsoft.Json;
namespace ShortestPath
{
    public abstract class Deserializer
    {
        protected readonly string _RawData;
        public Deserializer(string rawData)
        {
            _RawData = rawData;
        }
        public abstract List<Arc> Deserialize();
    }

    public class DeserializeRawString : Deserializer
    {
        public DeserializeRawString(string rawData) : base(rawData) { }
        public override List<Arc> Deserialize()
        {
            return JsonConvert.DeserializeObject<List<Arc>>(_RawData);
        }
    }
}
