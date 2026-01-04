namespace AdventOfCode.Y2025.Dec01
{
    internal class Puzzle2 : AdventPuzzle
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

                // Normalize distance to 0..99 range
                var extraTimesPast = Math.DivRem(distance, dialSize, out var remainder);
                count += extraTimesPast;

                var newPosition = (dial + direction * remainder);

                if (newPosition == 0)
                {
                    count++;
                }
                else if (newPosition < 0)
                {
                    newPosition = dialSize + newPosition;

                    if (dial != 0)
                        count++;
                }
                else if (newPosition > 99)
                {
                    newPosition = newPosition - dialSize;

                    if (dial != 0)
                        count++;
                }

                dial = newPosition;
                //var newPosition = (dial + direction * distance);

                //if (newPosition <= 0)
                //{
                //    var timesPast = Math.Abs(newPosition / 100) + 1;

                //    dial = (newPosition + timesPast * dialSize) % dialSize;
                //    count += timesPast;
                //}
                //else
                //{
                //    var timesPast = Math.DivRem(newPosition, dialSize, out dial);
                //    count += timesPast;
                //}
            }

            return count;
        }
    }
}
