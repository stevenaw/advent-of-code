namespace AdventOfCode.Y2016.Dec09
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
            => Decompression.CalculateExpandedLength(lines.First());
    }
}
