namespace AdventOfCode.Y2017.Dec09
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const char GARBAGE_START = '<';
            const char GARBAGE_END = '>';
            const char ESCAPE_NEXT = '!';

            var line = lines.ElementAt(0);

            bool consume = false;
            long totalGarbage = 0;

            for (int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case GARBAGE_START:
                        if (consume)
                        {
                            goto default;
                        }

                        consume = true;
                        break;
                    case GARBAGE_END:
                        consume = false;
                        break;
                    case ESCAPE_NEXT:
                        i++;
                        break;
                    default:
                        if (consume)
                        {
                            totalGarbage++;
                        }
                        break;
                }
            }

            return totalGarbage;
        }
    }
}
