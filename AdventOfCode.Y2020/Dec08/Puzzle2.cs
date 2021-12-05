using System.Collections.Generic;

namespace AdventOfCode.Y2020.Dec08
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var instructions = InstructionHelper.Parse(lines);

            for (var i = 0; i < instructions.Length; i++)
            {
                int result;
                if (TrySwapInstruction(instructions, i, Op.Jmp, Op.Nop, out result))
                    return result;

                if (TrySwapInstruction(instructions, i, Op.Nop, Op.Jmp, out result))
                    return result;
            }

            return 0;
        }

        private static bool TrySwapInstruction((Op op, int offset)[] instructions, int i, Op from, Op to, out int result)
        {
            if (instructions[i].op == from)
            {
                instructions[i].op = to;
                if (InstructionHelper.TryExecute(instructions, out result))
                    return true;

                instructions[i].op = from;
            }

            result = 0;
            return false;
        }
    }
}
