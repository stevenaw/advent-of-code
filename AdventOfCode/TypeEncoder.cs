namespace AdventOfCode
{
    public class TypeEncoder
    {
        public static long EncodeAsLong(ReadOnlySpan<char> s)
        {
            if (s.Length > 8)
                throw new InvalidOperationException("Can not encode string with length exceeding 8 characters");

            var result = 0L;
            var idx = s.Length;

            foreach (var c in s)
                result |= (c & 0xFF) << (--idx * 8);

            return result;
        }
    }
}
