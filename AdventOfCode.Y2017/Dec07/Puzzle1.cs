using System.Runtime.InteropServices;

namespace AdventOfCode.Y2017.Dec07
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var root = Node.ParseTree(lines);
            return TypeEncoder.EncodeLettersAsLong(root.Name);
        }
    }
}
