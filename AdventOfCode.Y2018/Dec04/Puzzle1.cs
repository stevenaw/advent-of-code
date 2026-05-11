namespace AdventOfCode.Y2018.Dec04
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sleepWindows = new Dictionary<int, int[]>();
            var sleepDurations = new Dictionary<int, int>();

            foreach (var nap in PuzzleHelper.EnumerateSleepWindows(lines))
            {
                if (!sleepDurations.ContainsKey(nap.guardId))
                {
                    sleepWindows[nap.guardId] = new int[60];
                    sleepDurations[nap.guardId] = 0;
                }

                sleepDurations[nap.guardId] += nap.sleepEnd - nap.sleepStart;

                for (var i = nap.sleepStart; i < nap.sleepEnd; i++)
                {
                    sleepWindows[nap.guardId][i]++;
                }
            }

            var guardAsleepMost = sleepDurations.GetKeyOfMaxValue();
            var minuteAsleepMost = sleepWindows[guardAsleepMost].IndexOfMaxValue();

            return guardAsleepMost * minuteAsleepMost;
        }
    }
}
