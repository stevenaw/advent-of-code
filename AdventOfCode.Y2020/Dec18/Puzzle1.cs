namespace AdventOfCode.Y2020.Dec18
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0L;

            foreach (var line in lines)
            {
                var expression = Expression.Parse<LtrExpression>(line);
                var result = expression.Evaluate();
                sum += result;
            }

            return sum;
        }

        public class LtrExpression : Expression
        {
            public override long Evaluate()
            {
                var value = Operands.First().Evaluate();

                for (var i = 0; i < Operators.Count; i++)
                {
                    if (Operators[i] == Operation.Add)
                        value += Operands[i + 1].Evaluate();
                    else if (Operators[i] == Operation.Multiply)
                        value *= Operands[i + 1].Evaluate();
                }

                return value;
            }
        }
    }
}
