namespace AdventOfCode.Y2015.Dec03
{
    internal record struct Coordinate
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Coordinate Translate(char move) => move switch
        {
            '<' => new Coordinate() { X = X - 1, Y = Y },
            '>' => new Coordinate() { X = X + 1, Y = Y },
            'v' => new Coordinate() { X = X, Y = Y - 1 },
            '^' => new Coordinate() { X = X, Y = Y + 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(move))
        };
    }
}
