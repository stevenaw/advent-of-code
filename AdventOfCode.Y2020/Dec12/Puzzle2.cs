namespace AdventOfCode.Y2020.Dec12
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var ship = new Ship();

            foreach (var (operation, magnitude) in InstructionParser.ParseLines(lines))
                ship.Move(operation, magnitude);

            return ship.ManhattanDistanceFromOrigin;
        }

        private class Ship
        {
            public int PosX { get; private set; } = 0;
            public int PosY { get; private set; } = 0;

            public int WaypointX { get; private set; } = 10;
            public int WaypointY { get; private set; } = 1;

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
                        WaypointY += magnitude;
                        break;
                    case 'S':
                        WaypointY -= magnitude;
                        break;
                    case 'E':
                        WaypointX += magnitude;
                        break;
                    case 'W':
                        WaypointX -= magnitude;
                        break;

                    case 'R':
                        magnitude = -magnitude;
                        goto case 'L';
                    case 'L':
                        if (Math.Abs(magnitude) == 180)
                        {
                            WaypointX = -WaypointX;
                            WaypointY = -WaypointY;
                        }
                        else if (magnitude != 0)
                        {
                            var newPos = RotateAroundOrigin(WaypointX, WaypointY, magnitude);
                            WaypointX = (int)Math.Round(newPos.x);
                            WaypointY = (int)Math.Round(newPos.y);
                        }
                        break;

                    default:
                    case 'F':
                        PosX += WaypointX * magnitude;
                        PosY += WaypointY * magnitude;

                        break;
                }
            }
        }

        private static double ConvertDegreesToRadians(double degrees) => Math.PI / 180 * degrees;

        private static (double x, double y) RotateAroundOrigin(int x, int y, int degrees)
        {
            var rads = ConvertDegreesToRadians(degrees);

            var s = Math.Sin(rads);
            var c = Math.Cos(rads);

            var xnew = x * c - y * s;
            var ynew = x * s + y * c;

            return (xnew, ynew);
        }
    }
}
