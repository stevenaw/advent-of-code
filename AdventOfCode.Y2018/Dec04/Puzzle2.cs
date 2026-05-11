namespace AdventOfCode.Y2018.Dec04
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sleepWindows = new Dictionary<int, int[]>();

            foreach (var nap in PuzzleHelper.EnumerateSleepWindows(lines))
            {
                if (!sleepWindows.ContainsKey(nap.guardId))
                {
                    sleepWindows[nap.guardId] = new int[60];
                }

                for (var i = nap.sleepStart; i < nap.sleepEnd; i++)
                {
                    sleepWindows[nap.guardId][i]++;
                }
            }

            var guardId = 0;
            var maxValue = 0;
            var minuteMostAsleep = 0;

            foreach (var kvp in sleepWindows)
            {
                var i = kvp.Value.IndexOfMaxValue();
                if (maxValue < kvp.Value[i])
                {
                    minuteMostAsleep = i;
                    maxValue = kvp.Value[i];
                    guardId = kvp.Key;
                }
            }

            return guardId * minuteMostAsleep;
        }
    }
}
