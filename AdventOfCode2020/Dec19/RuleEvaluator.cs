namespace AdventOfCode2020.Dec19
{
    class RuleEvaluator
    {
        public static bool DoesMatch(string line, Rule[] rules)
        {
            var matchCount = CountMatches(line, rules, rules[0], 0);
            return matchCount == line.Length;
        }

        private static int CountMatches(string line, Rule[] rulebook, Rule rule, int position)
        {
            if (rule is MonadRule monad)
                return line[position] == monad.Value ? 1 : 0;

            var compoundRule = rule as CompoundRule;

            foreach (var subRule in compoundRule.SubRules)
            {
                var matchesSubRule = true;
                var allMatchedChars = 0;

                for (var i = 0; i < subRule.Count && matchesSubRule; i++)
                {
                    var clauseNumber = subRule[i];
                    var clause = rulebook[clauseNumber];
                    var clausePosition = position + allMatchedChars;

                    var matchedChars = CountMatches(line, rulebook, clause, clausePosition);

                    matchesSubRule = matchedChars > 0;
                    allMatchedChars += matchedChars;
                }

                if (matchesSubRule)
                    return allMatchedChars;
            }

            return 0;
        }
    }
}
