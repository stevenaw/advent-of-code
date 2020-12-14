using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Dec12
{
    public static class InstructionParser
    {
        public static IEnumerable<(char operation, int magnitude)> ParseLines(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var span = line.AsSpan();

                var operation = span[0];
                var magnitude = Int32.Parse(span.Slice(1));

                yield return (operation, magnitude);
            }
        }
    }
}
