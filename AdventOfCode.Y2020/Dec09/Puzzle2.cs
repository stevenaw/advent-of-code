namespace AdventOfCode.Y2020.Dec09
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var numbers = lines.Select(o => long.Parse(o)).ToArray();

            var comboBreaker = Helpers.FindFirstToBreakPattern(numbers);
            var contiguousSum = Helpers.FindContiguousSum(numbers, comboBreaker);

            var items = contiguousSum.ToArray();
            Array.Sort(items);

            return items.First() + items.Last();
        }
    }
}
