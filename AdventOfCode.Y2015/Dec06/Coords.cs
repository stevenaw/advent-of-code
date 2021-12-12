namespace AdventOfCode.Y2015.Dec06
{
    internal ref struct Coords
    {
        public int X { get; init; }
        public int Y { get; init; }

        public static Coords Parse(ReadOnlySpan<char> line)
        {
            var comma = line.IndexOf(',');
            var x = int.Parse(line.Slice(0, comma));
            var y = int.Parse(line.Slice(comma + 1));

            return new Coords()
            {
                X = x,
                Y = y,
            };
        }
    }
}
