using System;

namespace AdventOfCode2020.Dec09
{
    static class Helpers
    {
        public static long FindFirstToBreakPattern(long[] numbers)
        {
            const int preambleSize = 25;

            for (var i = preambleSize; i < numbers.Length; i++)
            {
                var valid = false;
                for (var j = i - preambleSize; j < i && !valid; j++)
                    for (var k = i - preambleSize; k < i && !valid; k++)
                        valid = numbers[j] != numbers[k] && numbers[j] + numbers[k] == numbers[i];

                if (!valid)
                    return numbers[i];
            }

            return -1;
        }
        public static ArraySegment<long> FindContiguousSum(long[] numbers, long target)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                var sum = numbers[i];

                var j = i + 1;
                for (; j < numbers.Length && sum < target; j++)
                    sum += numbers[j];

                if (sum == target && j != i + 1)
                    return new ArraySegment<long>(numbers, i, j - i);
            }

            return ArraySegment<long>.Empty;
        }
    }
}
