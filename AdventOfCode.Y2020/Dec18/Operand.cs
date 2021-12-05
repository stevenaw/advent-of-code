namespace AdventOfCode.Y2020.Dec18
{
    public class Operand : IExpression
    {
        public long Value { get; set; }

        public long Evaluate() => Value;
    }
}
