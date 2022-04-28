namespace ShortestPath
{
    internal class Comparer : IComparer<KeyValuePair<string, double>>
    {
        public int Compare(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
        {
            return x.Value.CompareTo(y.Value);
        }
    }
}
