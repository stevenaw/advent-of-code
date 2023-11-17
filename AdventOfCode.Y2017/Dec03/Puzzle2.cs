using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Y2017.Dec03
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = int.Parse(lines.First());
            var cache = new Dictionary<Coords, int>
            {
                { new(0, 0), 1 }
            };

            var currentWidthFromOrigin = 0;
            var currentUnitVector = new Coords(1, 0);
            var currentCoord = new Coords(0, 0);

            // while current number < input
            //   move currentCoord by currentUnitVector
            //   calculate next number
            //     sum all values from around, using cache
            //   put number in cache
            //
            //   calculate if unit vector needs reorienting (TODO)


            throw new NotImplementedException();
        }

        private readonly record struct Coords (int X, int Y);
    }
}
