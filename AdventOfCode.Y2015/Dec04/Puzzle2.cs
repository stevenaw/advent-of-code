namespace AdventOfCode.Y2015.Dec04
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var finder = new HashFinder(lines.First());

            return finder.GetHashStartsWith("000000");
        }
    }
}
