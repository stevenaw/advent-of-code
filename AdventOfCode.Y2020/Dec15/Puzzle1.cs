namespace AdventOfCode.Y2020.Dec15
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var seed = ParsingHelpers.ParseIntegers(lines.First(), ',');
            var result = NumberGenerator.GetNthNumber(seed, 2020);
            return result;
        }
    }
}
