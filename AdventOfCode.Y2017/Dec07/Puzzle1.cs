namespace AdventOfCode.Y2017.Dec07
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var tree = Tree.Parse(lines);
            return TypeEncoder.EncodeLettersAsLong(tree.Root.Name);
        }
    }
}
