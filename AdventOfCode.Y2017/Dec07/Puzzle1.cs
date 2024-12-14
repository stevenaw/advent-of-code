namespace AdventOfCode.Y2017.Dec07
{
    internal class Puzzle1 : AdventPuzzle<string>
    {
        protected override string Solve(IEnumerable<string> lines)
        {
            var tree = Tree.Parse(lines);
            return tree.Root.Name;
        }
    }
}
