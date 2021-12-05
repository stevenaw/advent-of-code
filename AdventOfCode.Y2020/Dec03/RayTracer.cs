namespace AdventOfCode.Y2020.Dec03
{
    static class RayTracer
    {
        public static int CountObstacles(bool[][] lines, int xIncr, int yDecr)
        {
            var obstacles = 0;

            var x = 0;
            for (var i = 0; i < lines.Length; i += yDecr)
            {
                if (lines[i][x])
                    obstacles++;

                x = (x + xIncr) % lines[i].Length;
            }

            return obstacles;
        }
    }
}
