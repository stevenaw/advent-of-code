namespace AdventOfCode.Y2016.Dec07
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            return lines.Count(l => IsValid(l));
        }

        private static bool IsValid(ReadOnlySpan<char> line)
        {
            var tokens = Parser.Tokenize(line);

            for (var i = 0; i < tokens.Length; i += 2)
            {
                foreach(var aba in EnumerateAbaPatterns(tokens[i]))
                {
                    var bab = string.Create(3, aba, (buffer, state) =>
                    {
                        buffer[2] = buffer[0] = state[1];
                        buffer[1] = state[0];
                    });

                    for (var j = 1; j < tokens.Length; j += 2)
                        if (tokens[j].Contains(bab))
                            return true;
                }
            }

            return false;

            static IEnumerable<string> EnumerateAbaPatterns(string token)
            {
                for (var i = 0; i < token.Length - 2; i++)
                    if (token[i] == token[i + 2] && token[i + 1] != token[i])
                        yield return token.Substring(i, 3);
            }
        }
    }
}
