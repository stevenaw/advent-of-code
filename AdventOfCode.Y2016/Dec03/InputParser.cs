namespace AdventOfCode.Y2016.Dec03
{
    internal static class InputParser
    {
        public static (int a, int b, int c) Parse(string line) => Parse(line.AsSpan());

        public static (int a, int b, int c) Parse(ReadOnlySpan<char> line)
        {
            int a, b, c;

            line = line.Trim();

            var idx = line.IndexOf(' ');
            var needle = line.Slice(0, idx);
            a = int.Parse(needle);
            line = line.Slice(idx + 1).Trim();

            idx = line.IndexOf(' ');
            needle = line.Slice(0, idx);
            b = int.Parse(needle);
            line = line.Slice(idx + 1).Trim();

            c = int.Parse(line);

            return (a, b, c);
        }
    }
}
