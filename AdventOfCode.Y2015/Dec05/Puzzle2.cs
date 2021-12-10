namespace AdventOfCode.Y2015.Dec05
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var count = 0;

            foreach (var line in lines)
                if (IsNice(line))
                    count++;

            return count;
        }

        private static bool IsNice(ReadOnlySpan<char> line)
            => ConformsRule1(line) && ConformsRule2(line);

        private static bool ConformsRule1(ReadOnlySpan<char> line)
        {
            for (var i = 0; i < line.Length - 3; i++)
            {
                var t = line.Slice(i, 2);
                if (line.Slice(i + 2).IndexOf(t) != -1)
                    return true;
            }

            return false;
        }

        private static bool ConformsRule2(ReadOnlySpan<char> line)
        {
            for (var i = 0; i < line.Length - 2; i++)
                if (line[i] == line[i + 2])
                    return true;

            return false;
        }
    }
}
