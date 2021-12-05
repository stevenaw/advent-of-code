namespace AdventOfCode.Y2020.Dec14
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var enumerator = lines.GetEnumerator();
            var memory = new Dictionary<ulong, ulong>();

            enumerator.MoveNext();
            while (Initialization.TryParse(ref enumerator, out var initialization))
            {
                foreach (var assignment in initialization.Assignments)
                {
                    var newValue = assignment.Value & ~initialization.Mask | initialization.MaskOverrides;
                    memory[assignment.Address] = newValue;
                }
            }

            var overrideSum = 0UL;
            foreach (var kvp in memory)
                overrideSum += kvp.Value;

            return (long)overrideSum;
        }
    }
}
