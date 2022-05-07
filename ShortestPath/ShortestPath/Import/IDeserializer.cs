namespace ShortestPath
{
    public interface IDeserializer
    {
        List<Arc> Deserialize(string text);
    }
}
