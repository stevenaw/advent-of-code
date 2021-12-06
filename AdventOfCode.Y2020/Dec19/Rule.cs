namespace AdventOfCode.Y2020.Dec19
{
    abstract class Rule : IComparable<Rule>
    {
        public int RuleNumber { get; init; }

        public int CompareTo(Rule? other)
        {
            ArgumentNullException.ThrowIfNull(other);
            return RuleNumber.CompareTo(other.RuleNumber);
        }
    }

    class CompoundRule : Rule
    {
        public List<List<int>> SubRules { get; private set; } = new List<List<int>>();
    }

    class MonadRule : Rule
    {
        public char Value { get; init; }
    }
}
