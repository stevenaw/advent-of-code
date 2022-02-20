namespace AdventOfCode.Y2016.Dec07
{
    internal static class Parser
    {
        public static string[] Tokenize(ReadOnlySpan<char> line)
        {
            var tokens = new List<string>();
            var endSequence = '[';

            while (!line.IsEmpty)
            {
                var endDelim = line.IndexOf(endSequence);
                var seq = endDelim == -1 ? line : line.Slice(0, endDelim);

                tokens.Add(seq.ToString());

                endSequence = endSequence == '[' ? ']' : '[';
                line = line.Slice(Math.Min(seq.Length + 1, line.Length));
            }

            return tokens.ToArray();
        }
    }
}
