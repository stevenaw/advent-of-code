namespace AdventOfCode.Y2015.Dec10
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = lines.First();

            var result = Processor.Process(input, 50);

            return result.Length;
        }
    }
}
