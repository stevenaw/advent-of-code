namespace AdventOfCode.Y2017.Dec05
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var jumps = lines.Select(x => int.Parse(x)).ToArray();
            var i = 0;
            var stepCount = 0L;

            while (i >= 0 && i < jumps.Length)
            {
                i += jumps[i]++;
                stepCount++;
            }

            return stepCount;
        }
    }
}
