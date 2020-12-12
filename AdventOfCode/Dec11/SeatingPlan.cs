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

    class SeatingPlan
    {
        private SeatState[][] _seats;
        private int _length;
        private int _width;

        public SeatingPlan(SeatState[][] seats)
        {
            _seats = seats;
            _length = seats.Length;
            _width = seats[0].Length;
        }


        public bool TryMove()
        {
            var newLayout = GC.AllocateUninitializedArray<SeatState[]>(_length);
            var hasChanged = false;

            for(var i = 0; i < newLayout.Length; i++)
            {
                newLayout[i] = GC.AllocateUninitializedArray<SeatState>(_width);
                for (var j = 0; j < newLayout[i].Length; j++)
                {
                    if (_seats[i][j] == SeatState.Floor)
                    {
                        newLayout[i][j] = SeatState.Floor;
                    }
                    else
                    {
                        var neighbourCount = CountNeighbours(i, j);
                        if (_seats[i][j] == SeatState.Empty && neighbourCount == 0)
                        {
                            newLayout[i][j] = SeatState.Occupied;
                            hasChanged = true;
                        }
                        else if (_seats[i][j] == SeatState.Occupied && neighbourCount >= 4)
                        {
                            newLayout[i][j] = SeatState.Empty;
                            hasChanged = true;
                        }
                        else
                        {
                            newLayout[i][j] = _seats[i][j];
                        }
                    }
                }
            }

            _seats = newLayout;
            return hasChanged;
        }

        public int CountOccupiedSeats()
        {
            var count = 0;

            for (var i = 0; i < _seats.Length; i++)
            {
                for (var j = 0; j < _seats[i].Length; j++)
                {
                    if (_seats[i][j] == SeatState.Occupied)
                        count++;
                }
            }

            return count;
        }


        private int CountNeighbours(int x, int y)
        {
            var count = 0;
            var data = _seats;

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
