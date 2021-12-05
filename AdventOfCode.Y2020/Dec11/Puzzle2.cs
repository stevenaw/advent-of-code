using System.Collections.Generic;

namespace AdventOfCode.Y2020.Dec11
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var seatingPlan = SeatingPlan.Parse(lines);
            var seatingStrategy = new LineOfSightSeatingStrategy();

            var count = 0L;
            while (seatingPlan.TryMove(seatingStrategy, 5))
                count++;

            return seatingPlan.CountOccupiedSeats();
        }
    }

    class LineOfSightSeatingStrategy : ISeatingStrategy
    {
        public int CountNeighbours(SeatState[][] data, int x, int y)
        {
            var count = 0;

            if (CanSeeNeighbour(data, x, y, 1, 1))
                count++;
            if (CanSeeNeighbour(data, x, y, 1, 0))
                count++;
            if (CanSeeNeighbour(data, x, y, 1, -1))
                count++;
            if (CanSeeNeighbour(data, x, y, 0, -1))
                count++;
            if (CanSeeNeighbour(data, x, y, -1, -1))
                count++;
            if (CanSeeNeighbour(data, x, y, -1, 0))
                count++;
            if (CanSeeNeighbour(data, x, y, -1, 1))
                count++;
            if (CanSeeNeighbour(data, x, y, 0, 1))
                count++;

            return count;
        }

        private static bool CanSeeNeighbour(SeatState[][] data, int x, int y, int slopeX, int slopeY)
        {
            x += slopeX;
            y += slopeY;

            while (x >= 0 && y >= 0 && x < data.Length && y < data[x].Length)
            {
                if (data[x][y] == SeatState.Empty)
                    return false;
                else if (data[x][y] == SeatState.Occupied)
                    return true;

                x += slopeX;
                y += slopeY;
            }

            return false;
        }
    }
}
