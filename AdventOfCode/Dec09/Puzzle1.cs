using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Dec09
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var numbers = lines.Select(o => Int64.Parse(o)).ToArray();
            var comboBreaker = Helpers.FindFirstToBreakPattern(numbers);

            return comboBreaker;





            //Span<int> circularBuffer = stackalloc int[preambleSize];

            //// Build preamble
            //var lineEnumerator = lines.GetEnumerator();
            //for (var i = 0; i < preambleSize; i++)
            //{
            //    lineEnumerator.MoveNext();
            //    circularBuffer[i] = int.Parse(lineEnumerator.Current);
            //}

            //var idx = 0;
            //var invalidNumber = 0;
            //while (lineEnumerator.MoveNext())
            //{
            //    var nextNumber = int.Parse(lineEnumerator.Current);
            //    var valid = false;

            //    for(var i = 0; i < circularBuffer.Length && !valid; i++)
            //    {
            //        for (var j = 0; j < circularBuffer.Length && !valid; j++)
            //        {
            //            if (circularBuffer[i] != circularBuffer[j] && circularBuffer[i] + circularBuffer[j] == nextNumber)
            //            {
            //                valid = true;
            //            }
            //        }
            //    }

            //    if (valid)
            //    {
            //        circularBuffer[idx] = nextNumber;
            //        idx = (idx + 1) % preambleSize;
            //    }
            //    else
            //    {
            //        invalidNumber = nextNumber;
            //        break;
            //    }
            //}

            //return invalidNumber;
        }
    }
}
