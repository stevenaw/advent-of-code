namespace AdventOfCode.Y2025.Dec03
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
            => lines.Sum(x => PuzzleHelpers.GetMaxJoltage(x, 12));
    }
}
