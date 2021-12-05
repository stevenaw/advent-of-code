namespace AdventOfCode.Y2020.Dec19
{
    class DataParser
    {
        public static (Rule[] rules, List<string> results) ParseData(IEnumerable<string> lines)
        {
            var ruleLines = lines.TakeWhile(line => !string.IsNullOrWhiteSpace(line));
            var rules = ruleLines.Select(o => ParseRule(o)).OrderBy(o => o.RuleNumber).ToArray();

            var results = lines
                .Skip(rules.Length + 1)
                .ToList();

            return (rules, results);
        }

        private static Rule ParseRule(string line)
        {
            var lineSpan = line.AsSpan();
            Rule rule;

            var ruleNumDelim = lineSpan.IndexOf(':');
            var ruleNum = int.Parse(lineSpan.Slice(0, ruleNumDelim));

            lineSpan = lineSpan.Slice(ruleNumDelim + 2);
            if (lineSpan[0] == '"')
            {
                rule = new MonadRule()
                {
                    RuleNumber = ruleNum,
                    Value = lineSpan[1]
                };
            }
            else
            {
                var compoundRule = new CompoundRule() { RuleNumber = ruleNum };

                var reqRuleDelim = lineSpan.IndexOf('|');
                var reqRuleSpan = reqRuleDelim == -1 ? lineSpan : lineSpan.Slice(0, reqRuleDelim - 1);

                lineSpan = reqRuleDelim == -1 ? lineSpan.Slice(reqRuleSpan.Length) : lineSpan.Slice(reqRuleSpan.Length + 2);

                while (!reqRuleSpan.IsEmpty)
                {
                    var reqRuleList = ParsingHelpers.ParseIntegers(reqRuleSpan, ' ');

                    compoundRule.SubRules.Add(reqRuleList);

                    reqRuleDelim = lineSpan.IndexOf('|');
                    reqRuleSpan = reqRuleDelim == -1 ? lineSpan : lineSpan.Slice(0, reqRuleDelim - 1);
                    lineSpan = lineSpan.Slice(reqRuleSpan.Length);
                }

                rule = compoundRule;
            }

            return rule;
        }
    }
}
