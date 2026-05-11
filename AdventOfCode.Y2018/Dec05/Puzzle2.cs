namespace AdventOfCode.Y2018.Dec05
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var data = lines.First().ToArray();
            var min = data.Length;

            for (var i = 0; i < 26; i++)
            {
                Span<char> x = (char[])data.Clone();

                var target = (char)('a' + i);

                RemoveAll(ref x, target);

                min = Math.Min(min, PuzzleHelper.Condense(x));
            }

            return min;
        }

        private static void RemoveAll(ref Span<char> input, char c)
        {
            int idx = -1;
            var startIdx = 0;

            c = char.ToLower(c);

            do
            {
                idx = -1;
                for (int i = startIdx; i < input.Length; i++)
                {
                    if ((input[i] | 0x20) == c)
                    {
                        idx = i;
                        break;
                    }
                }
                if (idx != -1)
                {
                    for (var i = idx; i < input.Length - 1; i++)
                    {
                        input[i] = input[i + 1];
                    }
                    input = input[..^1];
                    startIdx = idx;
                }
            }
            while (idx != -1);
        }
    }
}
