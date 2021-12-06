namespace AdventOfCode.Y2015.Dec01
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var level = 0L;

            foreach (var line in lines)
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] == '(')
                        level++;
                    else if (line[i] == ')')
                        level--;

                    if (level < 0)
                        return i + 1;
                }

            return -1;
        }
    }
}
