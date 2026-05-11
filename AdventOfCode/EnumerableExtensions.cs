namespace AdventOfCode
{
    public static class EnumerableExtensions
    {
        public static IEnumerator<T> GetEnumerator<T>(this T[] source)
        {
            return ((IEnumerable<T>)source).GetEnumerator();
        }

        public static TKey GetKeyOfMaxValue<TKey, TValue>(this Dictionary<TKey, TValue> dict)
            where TValue : notnull, IComparable<TValue>
            where TKey : notnull
        {
            TKey keyOfMaxValue = default!;
            TValue maxValue = default!;

            foreach (var kvp in dict)
            {
                if (kvp.Value.CompareTo(maxValue) > 0)
                {
                    maxValue = kvp.Value;
                    keyOfMaxValue = kvp.Key;
                }
            }

            return keyOfMaxValue;
        }

        public static int IndexOfMaxValue<T>(this T[] data)
            where T : notnull, IComparable<T>
        {
            int indexOfMaxValue = 0;
            T maxValue = default!;

            for (var i = 0; i < data.Length; i++)
            {
                if (data[i].CompareTo(maxValue) > 0)
                {
                    maxValue = data[i];
                    indexOfMaxValue = i;
                }
            }

            return indexOfMaxValue;
        }

        public static void RemoveAll(this ref Span<char> input, char c)
        {
            c = char.ToLower(c);

            var writeIdx = 0;
            for (var i = 0; i < input.Length; i++)
            {
                // We can assume that the input is only ASCII letters,
                // so we can just flip the case bit and compare to the target character.
                if ((input[i] | 0x20) != c)
                {
                    input[writeIdx++] = input[i];
                }
            }

            input = input[..writeIdx];
        }
    }
}
