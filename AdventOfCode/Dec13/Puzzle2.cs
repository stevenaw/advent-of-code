using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Dec13
{
    class Puzzle2 : AdventPuzzle
    {
        // Chinese Remainder Theorem
        // 1. Find LCM of first 2
        //   1.a. All numbers are prime, so LCM is just x*y
        // 2. Count backwards until they are in correct position
        // 3. Increment by LCM of first 2 until the third number is in correct position
        // 4. Increment by LCM of first 3 until the fourth number is in correct position
        // etc

        protected override long Solve(IEnumerable<string> lines)
        {
            var buses = ParseInput(lines);
            var offsets = CalculateOffsetsOfValue(buses);

            // 1. Find lcm of first two
            long lcm = offsets[0].value * offsets[1].value;

            // 2. Initialize seive to intersection of first two
            long seiveValue;
            for (seiveValue = lcm; seiveValue >= 0; seiveValue -= offsets[0].value)
                if ((seiveValue + offsets[1].offset) % offsets[1].value == 0)
                    break;

            // 3+
            for(var i = 2; i < offsets.Length; i++)
            {
                var (value, offset) = offsets[i];
                while ((seiveValue + offset) % value != 0)
                    seiveValue += lcm;
                lcm *= value;
            }

            return seiveValue;
        }

        private static (int value, int offset)[] CalculateOffsetsOfValue(List<int> buses)
        {
            var offsets = new List<(int value, int offset)>();
            offsets.Add((buses[0], 0));

            for (var i = 1; i < buses.Count; i++)
            {
                if (buses[i] != 0)
                {
                    var value = buses[i];
                    var offset = i;

                    offsets.Add((value, offset));
                }
            }

            return offsets.ToArray();
        }

        private static List<int> ParseInput(IEnumerable<string> lines)
        {
            var enumerator = lines.GetEnumerator();

            enumerator.MoveNext();
            enumerator.MoveNext();

            var buses = new List<int>();
            var busesSpan = enumerator.Current.AsSpan();

            var nextDelim = busesSpan.IndexOf(',');
            while (!busesSpan.IsEmpty && nextDelim != -1)
            {
                var t = busesSpan.Slice(0, nextDelim);
                if (Int32.TryParse(t, out var num))
                    buses.Add(num);
                else
                    buses.Add(0);

                busesSpan = busesSpan.Slice(t.Length + 1);
                nextDelim = busesSpan.IndexOf(',');
            }

            if (Int32.TryParse(busesSpan, out var lastNum))
                buses.Add(lastNum);

            return buses;
        }
    }
}
