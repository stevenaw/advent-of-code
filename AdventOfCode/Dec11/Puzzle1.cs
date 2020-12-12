using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Dec11
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var seatingPlan = SeatingPlan.Parse(lines);
            var seatingStrategy = new AdjacentSeatingStrategy();

            var count = 0L;
            while (seatingPlan.TryMove(seatingStrategy))
                count++;

            return seatingPlan.CountOccupiedSeats();
        }

        public class AdjacentSeatingStrategy : ISeatingStrategy
        {
            public int CountNeighbours(SeatState[][] data, int x, int y)
            {
                var count = 0;

                for (var xCount = Math.Max(x - 1, 0); xCount <= Math.Min(x + 1, data.Length - 1); xCount++)
                {
                    for (var yCount = Math.Max(y - 1, 0); yCount <= Math.Min(y + 1, data[xCount].Length - 1); yCount++)
                    {
                        if (data[xCount][yCount] == SeatState.Occupied && (xCount != x || yCount != y))
                            count++;
                    }
                }

                return count;
            }
        }
    }
}
