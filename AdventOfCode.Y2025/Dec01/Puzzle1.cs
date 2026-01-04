namespace AdventOfCode.Y2025.Dec01
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const int dialSize = 100;

            var dial = 50;
            var count = 0L;

            foreach (var line in lines)
            {
                var l = line.AsSpan();

                var direction = l[0] == 'L' ? -1 : 1;
                var distance = int.Parse(l.Slice(1));

                dial = (dial + direction * distance) % dialSize;

                if (dial == 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
