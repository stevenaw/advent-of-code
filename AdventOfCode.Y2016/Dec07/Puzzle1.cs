namespace AdventOfCode.Y2016.Dec07
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            return lines.Count(l => IsValid(l));
        }

        private static bool IsValid(ReadOnlySpan<char> line)
        {
            var tokens = Tokenize(line);

            for (var i = 1; i < tokens.Length; i += 2)
                if (IsAbba(tokens[i]))
                    return false;

            for (var i = 0; i < tokens.Length; i += 2)
                if (IsAbba(tokens[i]))
                    return true;

            return false;

            static bool IsAbba(string token)
            {
                for (var i=0; i < token.Length-3; i++)
                    if (token[i] == token[i + 3] && token[i + 1] == token[i + 2] && token[i] != token[i + 1])
                        return true;
                return false;
            }
        }

        private static string[] Tokenize(ReadOnlySpan<char> line)
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
