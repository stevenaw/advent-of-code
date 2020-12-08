using System.Collections.Generic;

namespace AdventOfCode2020.Dec02
{
    public class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> fileContents)
        {
            var validCount = 0;

            foreach(var r in fileContents)
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
            foreach (var c in rule.Password)
                if (c == rule.Character)
                    count++;

            return count >= rule.Minimum && count <= rule.Maximum;
        }
    }
}
