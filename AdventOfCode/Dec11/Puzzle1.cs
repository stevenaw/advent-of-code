using System.Collections.Generic;

namespace AdventOfCode2020.Dec11
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var seatingPlan = SeatingPlan.Parse(lines);

            var count = 0L;
            while (seatingPlan.TryMove())
                count++;

            return seatingPlan.CountOccupiedSeats();
        }
    }
}
