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
            var tokens = Parser.Tokenize(line);

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
    }
}
