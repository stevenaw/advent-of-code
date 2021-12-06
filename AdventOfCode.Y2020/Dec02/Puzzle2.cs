namespace AdventOfCode.Y2020.Dec02
{
    public class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var validCount = 0;

            foreach (var r in lines)
            {
                var rule = Rule.Parse(r);
                if (IsValid(rule))
                    validCount++;
            }

            return validCount;
        }

        private static bool IsValid(Rule rule)
        {
            var count = 0;

            if (rule.Password[rule.Minimum - 1] == rule.Character)
                count++;

            if (rule.Password[rule.Maximum - 1] == rule.Character)
                count++;

            return count == 1;
        }
    }
}
