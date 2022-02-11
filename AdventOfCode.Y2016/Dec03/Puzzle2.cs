namespace AdventOfCode.Y2016.Dec03
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var count = 0L;

            foreach(var batch in lines.Chunk(3))
            {
                var itemA = InputParser.Parse(batch[0]);
                var itemB = InputParser.Parse(batch[1]);
                var itemC = InputParser.Parse(batch[2]);

                if (IsValidTriangle(itemA.a, itemB.a, itemC.a))
                    count++;
                if (IsValidTriangle(itemA.b, itemB.b, itemC.b))
                    count++;
                if (IsValidTriangle(itemA.c, itemB.c, itemC.c))
                    count++;
            }

            return count;
        }

        private static bool IsValidTriangle(int a, int b, int c) =>
            a + b > c
            && c + b > a
            && a + c > b;
    }
}
