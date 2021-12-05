using System;
using System.Collections.Generic;

namespace AdventOfCode.Y2020.Dec18
{
    public abstract class Expression : IExpression
    {
        public List<IExpression> Operands { get; set; } = new List<IExpression>();
        public List<Operation> Operators { get; set; } = new List<Operation>();

        public abstract long Evaluate();

        public static TExpression Parse<TExpression>(string line) where TExpression : Expression, new()
        {
            var expressionHistory = new Stack<TExpression>();
            var currentExpression = new TExpression();

            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '+')
                    currentExpression.Operators.Add(Operation.Add);
                else if (line[i] == '*')
                    currentExpression.Operators.Add(Operation.Multiply);
                else if (char.IsDigit(line[i]))
                    currentExpression.Operands.Add(new Operand()
                    {
                        Value = line[i] - '0'
                    });
                else if (line[i] == '(')
                {
                    var subExpression = new TExpression();

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
    }
}
