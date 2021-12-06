namespace AdventOfCode.Y2015.Dec02
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var total = 0L;
            var strategy = new RibbonWrappingStrategy();

            foreach (var line in lines)
                if (Dimensions.TryParse(line, out var value))
                    total += strategy.Calculate(value);

            return total;
        }
    }
}
