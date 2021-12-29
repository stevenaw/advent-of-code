namespace AdventOfCode.Y2015.Dec08
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var count = 0;

            foreach (var line in lines)
            {
                var allChars = line.Length;
                var encodedChars = CountEncodedCharacters(line);
                count += (encodedChars - allChars);
            }

            return count;
        }

        private static int CountEncodedCharacters(string line)
        {
            var toEscape = 0;

            for (var i = 0; i < line.Length; i++)
                if (line[i] == '\\' || line[i] == '"')
                    toEscape++;

            return line.Length + toEscape + 2;
        }
    }
}
