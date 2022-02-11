namespace AdventOfCode.Y2016.Dec03
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var count = 0;

            foreach (var line in lines)
            {
                var shape = InputParser.Parse(line);
                if (shape.a + shape.b > shape.c
                    && shape.c + shape.b > shape.a
                    && shape.a + shape.c > shape.b)
                    count++;
            }

            return count;
        }
    }
}
