namespace AdventOfCode.Y2020.Dec03
{
    public class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var trees = TreeParser.ParseTrees(lines);

            var result = 1L;
            foreach (var slope in Slopes)
                result *= RayTracer.CountObstacles(trees, slope.Item1, slope.Item2);

            return result;
        }

        static readonly (int, int)[] Slopes = new (int, int)[]
        {
            (1,1),
            (3,1),
            (5,1),
            (7,1),
            (1,2)
        };
    }
}
