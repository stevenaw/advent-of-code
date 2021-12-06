namespace AdventOfCode
{
    public static class ParsingHelpers
    {
        public static List<int> ParseIntegers(ReadOnlySpan<char> line, char delim)
        {
            var ids = new List<int>();

            var nextDelim = line.IndexOf(delim);
            while (!line.IsEmpty && nextDelim != -1)
            {
                var t = line.Slice(0, nextDelim);
                if (Int32.TryParse(t, out var num))
                    ids.Add(num);

                line = line.Slice(t.Length + 1);
                nextDelim = line.IndexOf(delim);
            }

            if (Int32.TryParse(line, out var lastNum))
                ids.Add(lastNum);

            return ids;
        }
    }
}
