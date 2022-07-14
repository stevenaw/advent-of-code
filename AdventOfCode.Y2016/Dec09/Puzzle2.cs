namespace AdventOfCode.Y2016.Dec09
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
            => Decompression.CalculateExpandedLength(lines.First(), recursive: true);
    }
}
