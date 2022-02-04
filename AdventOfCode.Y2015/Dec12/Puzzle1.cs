namespace AdventOfCode.Y2015.Dec12
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = lines.First();
            var sum = GetIntegers(input).Sum();

            return sum;
        }

        private static List<int> GetIntegers(ReadOnlySpan<char> s)
        {
            Span<char> digits = stackalloc char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var result = new List<int>();

            var startIdx = s.IndexOfAny(digits);

            while (startIdx != -1)
            {
                var len = 1;
                while (Char.IsDigit(s[startIdx + len]))
                    len++;

                if (s[startIdx-1] == '-')
                {
                    startIdx--;
                    len++;
                }

                result.Add(int.Parse(s.Slice(startIdx, len)));

                s = s[(startIdx + len)..];
                startIdx = s.IndexOfAny(digits);
            }

            return result;
        }
    }
}
