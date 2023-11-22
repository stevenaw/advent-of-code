using System.Runtime.InteropServices;

namespace AdventOfCode.Y2017.Dec06
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var input = lines.First().Split('\t');

            ArgumentOutOfRangeException.ThrowIfNotEqual(input.Length, 16);

            Span<byte> vals = stackalloc byte[16];
            for (var i = 0; i < input.Length; i++)
                vals[i] = byte.Parse(input[i]);
            
            var history = new HashSet<(ulong, ulong)>(32);


            var steps = 0;
            (ulong, ulong) state;

            do
            {
                steps++;

                Redistribute(vals);

                state = SnapshotState(vals);
            } while (history.Add(state));

            return steps;
        }

        private static void Redistribute(Span<byte> vals)
        {
            var highestIdx = 0;
            for (var i = 1;  i < vals.Length; i++)
            {
                if (vals[i] > vals[highestIdx])
                {
                    highestIdx = i;
                }
            }

            var highestVal = vals[highestIdx];
            vals[highestIdx] = 0;

            for (var i = 1; i <= highestVal; i++)
            {
                var idx = (highestIdx + i) % vals.Length;
                vals[idx]++;
            }
        }

        private static (ulong,ulong) SnapshotState(Span<byte> bytes)
        {
            var longs = MemoryMarshal.Cast<byte, ulong>(bytes);
            return (longs[0], longs[1]);
        }
    }
}
