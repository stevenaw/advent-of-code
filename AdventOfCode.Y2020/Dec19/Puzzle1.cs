namespace AdventOfCode.Y2020.Dec19
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var (rules, results) = DataParser.ParseData(lines);
            var count = 0;

            foreach (var line in results)
                if (RuleEvaluator.DoesMatch(line, rules))
                    count++;

            return count;
        }
    }
}
