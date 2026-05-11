namespace AdventOfCode.Y2018.Dec05
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var result = PuzzleHelper.Condense(lines.First().ToArray());
            return result;
        }
    }
}
