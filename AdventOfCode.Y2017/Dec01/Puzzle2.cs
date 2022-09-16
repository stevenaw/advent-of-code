namespace AdventOfCode.Y2017.Dec01
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var ids = ParsingHelpers.ParseIntegers(lines.First());
            var sum = 0L;
            var step = ids.Length / 2;

            for (var i = 0; i < ids.Length / 2; i++)
                if (ids[i] == ids[i + step])
                    sum += (ids[i] * 2);

            return sum;
        }
    }
}
