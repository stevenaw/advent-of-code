namespace AdventOfCode
{
    public class TypeEncoder
    {
        public static long EncodeAsLong(string s) => EncodeAsLong(s.AsSpan());

        public static long EncodeAsLong(ReadOnlySpan<char> s)
        {
            var result = 0L;
            var idx = s.Length;

            foreach (var c in s)
                result |= ((byte)c) << (--idx * 8);

            return result;
        }
    }
}
