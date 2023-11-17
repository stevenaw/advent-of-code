namespace AdventOfCode.Y2017.Dec04
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var validCount = 0L;

            foreach(var line in lines)
            {
                var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var distinctCount = tokens.Select(x => string.Create(x.Length, x, (buffer, state) =>
                {
                    var chars = state.ToCharArray();
                    Array.Sort(chars);
                    chars.CopyTo(buffer);
                }))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Count();

                if (distinctCount == tokens.Length)
                {
                    validCount++;
                }
            }

            return validCount;
        }
    }
}
