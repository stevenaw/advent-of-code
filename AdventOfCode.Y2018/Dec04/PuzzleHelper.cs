namespace AdventOfCode.Y2018.Dec04
{
    internal static class PuzzleHelper
    {
        public static IEnumerable<(int guardId, int sleepStart, int sleepEnd)> EnumerateSleepWindows(IEnumerable<string> lines)
        {
            var data = lines.ToArray();
            Array.Sort(data);

            var guardId = 0;
            var sleepStart = 0;

            foreach (var line in data)
            {
                var l = line.AsSpan(1); // trim leading '['

                var idx = l.IndexOf(']');
                var ts = DateTime.Parse(l.Slice(0, idx));
                var desc = l.Slice(idx + 2);

                if (desc.StartsWith("Guard #", StringComparison.Ordinal))
                {
                    var desc2 = desc.Slice(7);
                    var end = desc2.IndexOf(' ');

                    guardId = int.Parse(desc2.Slice(0, end));
                    sleepStart = 0;
                }
                else if (desc.Equals("falls asleep", StringComparison.Ordinal))
                {
                    sleepStart = ts.Minute;
                }
                else if (desc.Equals("wakes up", StringComparison.Ordinal))
                {
                    yield return (guardId, sleepStart, ts.Minute);
                }
            }
        }

        private ref struct GuardAction(DateTime ts, ReadOnlySpan<char> desc)
        {
            public readonly DateTime ts = ts;
            public readonly ReadOnlySpan<char> desc = desc;

            internal static GuardAction Parse(string line)
            {
                

                return new GuardAction();
            }
        }
    }
}
