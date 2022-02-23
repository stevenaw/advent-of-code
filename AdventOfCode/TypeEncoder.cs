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

        public static long EncodeLettersAsLong(ReadOnlySpan<char> s)
        {
            // 26 letters, each upper/lower case.
            // 5 bytes to store letter, one to store casing flag
            // Can encode up to floor(64 / 6) = 10 letters
            if (s.Length > 10)
                throw new InvalidOperationException("Can not encode string with length exceeding 8 characters");

            var result = 0L;
            var idx = s.Length;

            foreach (var c in s)
            {
                if (!Char.IsLetter(c))
                    throw new InvalidOperationException("Only a-z letters are supported");

                var bits = Char.ToLower(c) - 'a';
                if (bits < 0 || bits >= 26)
                    throw new InvalidOperationException("Only a-z letters are supported");

                if (Char.IsUpper(c))
                    bits |= 32;

                result |= (bits & 63) << (--idx * 6);
            }

            return result;
        }
    }
}
