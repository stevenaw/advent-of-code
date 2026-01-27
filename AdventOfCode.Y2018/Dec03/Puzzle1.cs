namespace AdventOfCode.Y2018.Dec03
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const int TotalWidth = 1000;
            const int TotalHeight = 1000;

            var fabric = new byte[TotalWidth, TotalHeight];
            var overlapCount = 0;

            foreach (var line in lines)
            {
                var (_, left, top, width, height) = Claim.ParseClaim(line);

                for (var y = top; y < top + height; y++)
                {
                    for (var x = left; x < left + width; x++)
                    {
                        ref var sq = ref fabric[x, y];

                        // avoid overflows
                        sq = (byte)Math.Min(sq + 1, (byte)2);
                    }
                }
            }

            for (var y = 0; y < TotalWidth; y++)
            {
                for (var x = 0; x < TotalHeight; x++)
                {
                    if (fabric[x, y] == 2)
                    {
                        overlapCount++;
                    }
                }
            }

            return overlapCount;
        }
    }
}
