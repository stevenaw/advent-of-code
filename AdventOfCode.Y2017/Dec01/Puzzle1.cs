namespace AdventOfCode.Y2017.Dec01
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var ids = ParsingHelpers.ParseIntegers(lines.First());
            var sum = 0L;

            for (var i = 0; i < ids.Length -1; i++)
                if (ids[i] == ids[i+1])
                    sum += ids[i];

            if (ids[0] == ids[ids.Length - 1])
                sum += ids[0];

            return sum;
        }
    }
}
