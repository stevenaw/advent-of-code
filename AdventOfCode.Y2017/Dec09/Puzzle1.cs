namespace AdventOfCode.Y2017.Dec09
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const char GROUP_START = '{';
            const char GROUP_END = '}';
            const char GARBAGE_START = '<';
            const char GARBAGE_END = '>';
            const char ESCAPE_NEXT = '!';

            var line = lines.ElementAt(0);

            int depth = 0;
            int sum = 0;
            bool consume = true;

            for(int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case GROUP_START:
                        if (consume)
                        {
                            depth++;
                        }
                        break;
                    case GROUP_END:
                        if (consume)
                        {
                            sum += depth;
                            depth--;
                        }
                        break;
                    case GARBAGE_START:
                        consume = false;
                        break;
                    case GARBAGE_END:
                        consume = true;
                        break;
                    case ESCAPE_NEXT:
                        i++;
                        break;
                }
            }

            return sum;
        }
    }
}
