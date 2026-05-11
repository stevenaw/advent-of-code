namespace AdventOfCode.Y2018.Dec04
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var data = lines.ToArray();
            Array.Sort(data);

            var sleepWindows = new Dictionary<int, int[]>();
            var sleepDurations = new Dictionary<int, int>();
            var currentGuard = 0;
            var sleepStart = 0;

            foreach (var line in data)
            {
                var x = GuardAction.Parse(line);

                if (x.desc.StartsWith("Guard #", StringComparison.Ordinal))
                {
                    var x2 = x.desc.Slice(7);
                    var end = x2.IndexOf(' ');

                    currentGuard = int.Parse(x2.Slice(0, end));
                    sleepStart = 0;

                    if (!sleepDurations.ContainsKey(currentGuard))
                    {
                        sleepWindows[currentGuard] = new int[60];
                        sleepDurations[currentGuard] = 0;
                    }
                }
                else if (x.desc.Equals("falls asleep", StringComparison.Ordinal))
                {
                    sleepStart = x.ts.Minute;
                }
                else if (x.desc.Equals("wakes up", StringComparison.Ordinal))
                {
                    var duration = x.ts.Minute - sleepStart;

                    sleepDurations[currentGuard] += duration;

                    for (var i = sleepStart; i < x.ts.Minute; i++)
                    {
                        sleepWindows[currentGuard][i]++;
                    }
                }
            }

            var guardAsleepMost = sleepDurations.GetKeyOfMaxValue();
            var minuteAsleepMost = sleepWindows[guardAsleepMost].IndexOfMaxValue();

            return guardAsleepMost * minuteAsleepMost;
        }

        

        internal ref struct GuardAction(DateTime ts, ReadOnlySpan<char> desc)
        {
            public readonly DateTime ts = ts;
            public readonly ReadOnlySpan<char> desc = desc;

            internal static GuardAction Parse(string line)
            {
                var l = line.AsSpan(1); // trim leading '['

                var idx = l.IndexOf(']');
                var ts = l.Slice(0, idx);
                var desc = l.Slice(idx + 2);

                return new GuardAction(DateTime.Parse(ts), desc);
            }
        }
    }
}
