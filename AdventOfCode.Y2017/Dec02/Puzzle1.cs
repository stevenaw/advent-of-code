namespace AdventOfCode.Y2017.Dec02
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0L;

            foreach (var line in lines)
            {
                var ids = ParsingHelpers.ParseIntegers(line, '\t');

                var min = ids[0];
                var max = ids[0];

                for (var i = 1; i < ids.Count; i++)
                {
                    min = Math.Min(min, ids[i]);
                    max = Math.Max(max, ids[i]);
                }

                sum += max - min;
            }

            return sum;
        }
    }
}
