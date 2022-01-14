namespace AdventOfCode.Y2015.Dec10
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = lines.First();

            var result = LookSaySequence.Generate(input, 40);

            return result.Length;
        }
    }
}
