namespace AdventOfCode.Y2015.Dec07
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var ops = lines.Select(Operation.Parse).ToList();
            var a = OperationResolver.GetValue("a", ops);

            var b = ops.First(o => o.Destination == "b");
            b.Args = new[] { a.ToString() };

            a = OperationResolver.GetValue("a", ops);
            return a;
        }
    }
}
