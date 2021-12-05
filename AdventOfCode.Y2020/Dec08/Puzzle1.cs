using System.Collections.Generic;

namespace AdventOfCode.Y2020.Dec08
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var instructions = InstructionHelper.Parse(lines);

            InstructionHelper.TryExecute(instructions, out int result);

            return result;
        }
    }
}
