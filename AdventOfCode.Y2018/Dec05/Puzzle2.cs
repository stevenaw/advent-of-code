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
