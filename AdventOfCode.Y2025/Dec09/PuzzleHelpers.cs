namespace AdventOfCode.Y2025.Dec09
{
    internal record Point(int X, int Y)
    {
        public static Point Parse(string line)
        {
            var idx = line.IndexOf(',');

            return new Point(
                int.Parse(line.AsSpan(0, idx)),
                int.Parse(line.AsSpan(idx+1))
            );
        }
    }
}
