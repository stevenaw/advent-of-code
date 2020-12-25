using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Dec18
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0L;

            foreach(var line in lines)
            {
                var expression = ParseExpression(line);
                var result = expression.Evaluate();
                sum += result;
            }

            return sum;
        }

        private static Expression ParseExpression(string line)
        {
            var expressionHistory = new Stack<Expression>();
            var currentExpression = new Expression();

            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '+')
                    currentExpression.Operators.Add(Operation.Add);
                else if (line[i] == '*')
                    currentExpression.Operators.Add(Operation.Multiply);
                else if (Char.IsDigit(line[i]))
                    currentExpression.Operands.Add(new Operand()
                    {
                        Value = line[i] - '0'
                    });
                else if (line[i] == '(')
                {
                    var subExpression = new Expression();

                    currentExpression.Operands.Add(subExpression);

                    expressionHistory.Push(currentExpression);
                    currentExpression = subExpression;
                }
                else if (line[i] == ')')
                {
                    currentExpression = expressionHistory.Pop();
                }
            }

            return currentExpression;
        }

        public enum Operation
        {
            Add,
            Multiply
        }

        public class Operand : IExpression
        {
            public long Value { get; set; }

            public long Evaluate()
            {
                return Value;
            }
        }

        public interface IExpression
        {
            long Evaluate();
        }

        public class Expression : IExpression
        {
            public List<IExpression> Operands { get; set; } = new List<IExpression>();
            public List<Operation> Operators { get; set; } = new List<Operation>();

            public long Evaluate()
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
