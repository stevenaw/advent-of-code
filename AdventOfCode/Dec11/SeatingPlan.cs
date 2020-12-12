using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Dec11
{
    enum SeatState : byte
    {
        Floor = 64,
        Occupied = 1,
        Empty = 0
    }

    interface ISeatingStrategy
    {
        int CountNeighbours(SeatState[][] data, int x, int y);
    }

    class SeatingPlan
    {
        private SeatState[][] Seats { get; set; }

        public SeatingPlan(SeatState[][] seats)
        {
            Seats = seats;
        }


        public bool TryMove(ISeatingStrategy seatingStrategy)
        {
            var newLayout = GC.AllocateUninitializedArray<SeatState[]>(Seats.Length);
            var hasChanged = false;

            for(var i = 0; i < newLayout.Length; i++)
            {
                newLayout[i] = GC.AllocateUninitializedArray<SeatState>(Seats[i].Length);
                for (var j = 0; j < newLayout[i].Length; j++)
                {
                    if (Seats[i][j] == SeatState.Floor)
                    {
                        newLayout[i][j] = SeatState.Floor;
                    }
                    else
                    {
                        var neighbourCount = seatingStrategy.CountNeighbours(Seats, i, j);
                        if (Seats[i][j] == SeatState.Empty && neighbourCount == 0)
                        {
                            newLayout[i][j] = SeatState.Occupied;
                            hasChanged = true;
                        }
                        else if (Seats[i][j] == SeatState.Occupied && neighbourCount >= 4)
                        {
                            newLayout[i][j] = SeatState.Empty;
                            hasChanged = true;
                        }
                        else
                        {
                            newLayout[i][j] = Seats[i][j];
                        }
                    }
                }
            }

            Seats = newLayout;
            return hasChanged;
        }

        public int CountOccupiedSeats()
        {
            var count = 0;

            for (var i = 0; i < Seats.Length; i++)
            {
                for (var j = 0; j < Seats[i].Length; j++)
                {
                    if (Seats[i][j] == SeatState.Occupied)
                        count++;
                }
            }

            return count;
        }

        public static SeatingPlan Parse(IEnumerable<string> lines)
        {
            var result = lines.Select(o => ParseLine(o)).ToArray();

            return new SeatingPlan(result);
        }

        private static SeatState[] ParseLine(string line)
        {
            const char FloorChar = '.';
            const char EmptySeatChar = 'L';
            const char OccupiedSeatChar = '#';

            var result = new SeatState[line.Length];
            for(var i = 0; i < line.Length; i++)
            {
                result[i] = line[i] switch
                {
                    FloorChar => SeatState.Floor,
                    OccupiedSeatChar => SeatState.Occupied,
                    EmptySeatChar => SeatState.Empty
                };
            }

            return result;
        }
    }
}
