namespace AdventOfCode.Y2016.Dec01
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var headingIdx = 0;
            Span<(int deltaX, int deltaY)> movements = stackalloc (int, int)[] {
                (0, 1),
                (1, 0),
                (0, -1),
                (-1, 0)
            };
            var coords = (x: 0, y: 0);

            foreach(var command in InputParser.ParseCommands(lines.First()))
            {
                var delta = command.Direction == 'R' ? 1 : -1;

                headingIdx = ((headingIdx + delta) + movements.Length) % movements.Length;

                ref var change = ref movements[headingIdx];
                coords.x += change.deltaX * command.Distance;
                coords.y += change.deltaY * command.Distance;
            }

            return Math.Abs(coords.x) + Math.Abs(coords.y);
        }
    }

    public static class InputParser
    {
        public static IEnumerable<(char Direction, int Distance)> ParseCommands(ReadOnlySpan<char> line)
        {
            var items = new List<(char, int)>();

            var nextDelim = line.IndexOf(',');
            while (!line.IsEmpty && nextDelim != -1)
            {
                var t = line[..nextDelim].Trim();
                items.Add((t[0], int.Parse(t[1..])));

                line = line[(t.Length + 1)..].Trim();
                nextDelim = line.IndexOf(',');
            }

            items.Add((line[0], int.Parse(line[1..])));

            return items;
        }
    }
}
