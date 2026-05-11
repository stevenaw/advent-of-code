namespace AdventOfCode.Y2018.Dec05
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var result = Condense(lines.First().ToArray());
            return result;
        }

        private static int Condense(Span<char> input)
        {
            int idx = -1;
            var startIdx = 0;

            const int diff = 'a' - 'A';

            do
            {
                idx = -1;
                for (int i = startIdx; i < input.Length - 1; i++)
                {
                    // We can assume that the input is only ASCII letters,
                    // so we can just check the difference between the two characters
                    // to see if they are the same letter in different cases.
                    if (Math.Abs(input[i] - input[i + 1]) == diff)
                    {
                        idx = i;
                        break;
                    }
                }

                if (idx != -1)
                {
                    for (var i = idx; i < input.Length - 2; i++)
                    {
                        input[i] = input[i + 2];
                    }

                    input = input[..^2];
                    startIdx = Math.Max(0, idx - 1);
                }
            }
            while (idx != -1);

            return input.Length;
        }
    }
}
