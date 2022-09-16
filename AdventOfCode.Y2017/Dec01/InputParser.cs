namespace AdventOfCode.Y2016.Dec01
{
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
