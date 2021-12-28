namespace AdventOfCode.Y2015.Dec07
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            return OperationResolver.GetValue("a", lines.Select(Operation.Parse));
        }
    }
}
