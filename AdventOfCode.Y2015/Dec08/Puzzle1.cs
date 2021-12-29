namespace AdventOfCode.Y2015.Dec08
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var count = 0;

            foreach(var line in lines)
            {
                var allChars = line.Length;
                var displayableChars = CountDisplayableCharacters(line);
                count += (allChars - displayableChars);
            }

            return count;
        }

        private static int CountDisplayableCharacters(ReadOnlySpan<char> line)
        {
            if (line[0] == '"')
                line = line[1..];
            if (line[^1] == '"')
                line = line[0..^1];

            var count = 0;
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '\\')
                {
                    if (line[i + 1] == 'x')
                        i += 3;
                    else
                        i++;
                }
                
                count++;
            }
            return count;
        }
    }
}
