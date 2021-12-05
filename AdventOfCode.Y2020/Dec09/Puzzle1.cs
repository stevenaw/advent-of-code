namespace AdventOfCode.Y2020.Dec09
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var numbers = lines.Select(o => long.Parse(o)).ToArray();
            var comboBreaker = Helpers.FindFirstToBreakPattern(numbers);

            return comboBreaker;
        }
    }
}
