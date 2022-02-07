namespace AdventOfCode.Y2016.Dec03
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var count = 0;

            foreach (var line in lines)
            {
                var items = Parse(line);
                if (items.a + items.b > items.c
                    && items.c + items.b > items.a
                    && items.a + items.c > items.b)
                    count++;
            }

            return count;
        }

        private static (int a, int b, int c) Parse(ReadOnlySpan<char> line)
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
