using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Y2016.Dec02
{
    internal class Puzzle2 : AdventPuzzle
    {
        private static readonly bool[] _allowed = new bool[25]
        {
            false, false, true, false, false,
            false, true, true, true, false,
            true, true, true, true, true,
            false, true, true, true, false,
            false, false, true, false, false,
        };

        protected override long Solve(IEnumerable<string> lines)
        {
            var result = "";
            var position = 10;

            foreach (var line in lines)
            {
                foreach (var move in line)
                    position = GetNextPosition(position, move);

                var digit = Translate(position);
                result += digit;
            }

            Console.WriteLine(result);

            return TypeEncoder.EncodeAsLong(result);
        }

        private static char Translate(int current)
        {
            var count = 0;

            for(var i = 0; i < _allowed.Length; i++)
            {
                if (_allowed[i])
                    count++;

                if (i == current)
                    return count < 10 ? (char)(count + '0') : (char)((count-10) + 'A');
            }

            throw new InvalidOperationException("Could not find");
        }

        private static int GetNextPosition(int current, char move)
        {
            var delta = move switch
            {
                'U' => -5,
                'D' => 5,
                'L' => current % 5 == 0 ? 0 : -1,
                'R' => (current+1) % 5 == 0 ? 0 : 1,
                _ => throw new InvalidOperationException("unknown move")
            };

            if (delta != 0)
            {
                var next = current + delta;
                if (next < 0 || next >= 25)
                    delta = 0;
                else if (!_allowed[next])
                    delta = 0;
            }

            return current + delta;
        }
    }
}
