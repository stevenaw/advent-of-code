namespace AdventOfCode.Y2015.Dec20
{
    internal class Puzzle2 : AdventPuzzle
    {
        private const int HousesPerElf = 50;
        private const int GiftsPerHouse = 11;

        protected override long Solve(IEnumerable<string> lines)
        {
            var target = long.Parse(lines.First());

            for (var i = 1; i < target / GiftsPerHouse; i++)
            {
                var gifts = FactorizationHelpers.GetFactors(i)
                    .Where(x => x * HousesPerElf >= i)
                    .Select(x => x * GiftsPerHouse)
                    .Sum();

                if (gifts >= target)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
