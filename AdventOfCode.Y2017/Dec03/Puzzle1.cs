namespace AdventOfCode.Y2017.Dec03
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = int.Parse(lines.First());
            if (input == 1)
                return 0;

            // the ring has max value of a perfect square of successive odd numbers
            // Get the full width by finding the appropriate root of the max value
            var sqrt = Math.Sqrt(input);
            var width = (int)Math.Ceiling(sqrt) | 1;
            var bandMaxValue = (int)Math.Pow(width, 2);

            // Convert input to cartesian coordinates (don't need exact)
            // The "long axis difference" is merely floor(width / 2), or more simply '(width-1) >> 1' since we know width is odd
            var distanceFromOriginA = (width - 1) >> 1;

            // "short axis diff" is the distance from a midway point on the edge
            // do this by 'normalizing' it to be just before the max value by jumping 'width' around the outside
            // Pre-calculate the number of jumps based on the total distance
            var jumps = (bandMaxValue - input) / (width - 1);
            input += jumps * (width - 1);

            var midway = (bandMaxValue - distanceFromOriginA);
            var distanceFromOriginB = Math.Abs(input - midway);

            return distanceFromOriginA + distanceFromOriginB;
        }
    }
}
