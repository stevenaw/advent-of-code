using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Y2016.Dec03
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var items = lines.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToArray();
            var count = 0L;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 2; j < items.Length; j+=3)
                {
                    var shape = (a: items[j][i], b: items[j-1][i], c: items[j-2][i]);

                    if (shape.a + shape.b > shape.c
                    && shape.c + shape.b > shape.a
                    && shape.a + shape.c > shape.b)
                        count++;
                }
            }

            return count;
        }
    }
}
