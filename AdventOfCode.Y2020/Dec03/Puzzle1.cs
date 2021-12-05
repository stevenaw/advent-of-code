using System.Collections.Generic;

namespace AdventOfCode.Y2020.Dec03
{
    public class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> fileContents)
        {
            var trees = TreeParser.ParseTrees(fileContents);
            var result = RayTracer.CountObstacles(trees, 3, 1);

            return result;
        }
    }
}
