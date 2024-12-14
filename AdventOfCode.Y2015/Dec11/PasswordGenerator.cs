namespace AdventOfCode.Y2015.Dec11
{
    internal static class PasswordGenerator
    {
        public static string GenerateNthPassword(string seed, int n)
        {
            var chars = seed.ToCharArray().AsSpan();
            var result = new string[n];

            for (var i = 0; i < n; i++)
            {
                do
                {
                    Increment(chars);
                } while (!FollowsRule1(chars) || !FollowsRule2(chars) || !FollowsRule3(chars));

                result[i] = chars.ToString()!;
            }

            return result[n-1];
        }

        private static bool FollowsRule1(ReadOnlySpan<char> chars)
        {
            for (var i = 0; i < chars.Length - 2; i++)
                if (chars[i] + 1 == chars[i + 1] && chars[i + 1] + 1 == chars[i + 2])
                    return true;
            return false;
        }

        private static bool FollowsRule2(ReadOnlySpan<char> chars)
        {
            return chars.IndexOfAny('i', 'o', 'l') == -1;
        }

        private static bool FollowsRule3(ReadOnlySpan<char> chars)
        {
            var pairCount = 0;
            for (var i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    pairCount++;
                    i++;
                }
            }
            return pairCount > 1;
        }

        private static void Increment(Span<char> chars)
        {
            var idx = chars.Length - 1;
            while (idx >= 0 && Increment(chars, idx))
                idx--;
        }

        private static bool Increment(Span<char> chars, int i)
        {
            if (chars[i] == 'z')
            {
                chars[i] = 'a';
                return true;
            }
            else
            {
                chars[i]++;
                return false;
            }
        }
    }
}
