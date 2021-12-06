namespace AdventOfCode.Y2015.Dec01
{
    public class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> fileContents)
        {
            var level = 0L;

            foreach(var line in fileContents)
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] == '(')
                        level++;
                    else if (line[i] == ')')
                        level--;
                }

            return level;
        }
    }
}
