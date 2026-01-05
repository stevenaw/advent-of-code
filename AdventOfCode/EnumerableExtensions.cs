namespace AdventOfCode
{
    public static class EnumerableExtensions
    {
        public static IEnumerator<T> GetEnumerator<T>(this T[] source)
        {
            return ((IEnumerable<T>)source).GetEnumerator();
        }
    }
}
