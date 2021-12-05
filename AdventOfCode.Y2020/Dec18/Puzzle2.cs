using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Y2020.Dec18
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0L;

            foreach (var line in lines)
            {
                var expression = Expression.Parse<AdditionFirstExpression>(line);
                var result = expression.Evaluate();
                sum += result;
            }

            return sum;
        }

        public class AdditionFirstExpression : Expression
        {
            public override long Evaluate()
            {
                var operands = Operands.ToList();
                var operators = Operators.ToList();

                var precedenceOrder = new[] { Operation.Add, Operation.Multiply };

                foreach (var operation in precedenceOrder)
                {
                    for (var i = 0; i < operators.Count; i++)
                    {
                        if (operators[i] == operation)
                        {
                            var left = operands[i].Evaluate();
                            var right = operands[i + 1].Evaluate();
                            var resolvedValue = operation == Operation.Add ? left + right : left * right;

                            // Left-associate
                            operands[i] = new Operand() { Value = resolvedValue };

                            operands.RemoveAt(i + 1);
                            operators.RemoveAt(i);
                            i--;
                        }
                    }
                }

                return operands[0].Evaluate();
            }
        }
    }
}
