using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Dec12
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var ship = new Ship();

            foreach(var line in lines)
            {
                var span = line.AsSpan();

                var action = span[0];
                var magnitude = Int32.Parse(span.Slice(1));

                ship.Move(action, magnitude);
            }

            return ship.ManhattanDistanceFromOrigin;
        }

        private class Ship
        {
            public int PosX { get; private set; } = 0;
            public int PosY { get; private set; } = 0;
            public int OrientationDegrees { get; private set; } = 0;

            public int ManhattanDistanceFromOrigin
            {
                get
                {
                    return Math.Abs(PosX) + Math.Abs(PosY);
                }
            }

            public void Move(char movement, int magnitude)
            {
                switch (movement)
                {
                    case 'N':
                        PosY += magnitude;
                        break;
                    case 'S':
                        PosY -= magnitude;
                        break;
                    case 'E':
                        PosX += magnitude;
                        break;
                    case 'W':
                        PosX -= magnitude;
                        break;

                    case 'R':
                        OrientationDegrees = (OrientationDegrees + magnitude) % 360;
                        break;
                    case 'L':
                        OrientationDegrees = Math.Abs(OrientationDegrees - magnitude + 360) % 360;
                        break;

                    default:
                    case 'F':
                        if (OrientationDegrees == 0)
                            goto case 'E';
                        else if (OrientationDegrees == 90)
                            goto case 'S';
                        else if (OrientationDegrees == 180)
                            goto case 'W';
                        else if (OrientationDegrees == 270)
                            goto case 'N';

                        break;
                }
            }
        }
    }
}
