using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Dec08
{
    public enum Op
    {
        Acc,
        Jmp,
        Nop
    }

    static class InstructionHelper
    {
        public static bool TryExecute((Op op, int offset)[] instructions, out int result)
        {
            Span<bool> executedLines = stackalloc bool[instructions.Length];

            var i = 0;
            var acc = 0;

            while (!executedLines[i])
            {
                var instruction = instructions[i];

                executedLines[i] = true;

                switch (instruction.op)
                {
                    case Op.Nop:
                        {
                            i++;
                            break;
                        }

                    case Op.Acc:
                        {
                            i++;
                            acc += instruction.offset;
                            break;
                        }

                    case Op.Jmp:
                        {
                            i += instruction.offset;
                            break;
                        }
                }
            }

            result = acc;
            return i == instructions.Length;
        }

        public static (Op op, int offset)[] Parse(IEnumerable<string> instructions)
        {
            return instructions.Select(o => Parse(o)).ToArray();
        }

        private static (Op op, int offset) Parse(string instruction)
        {
            var result = default((Op op, int offset));

            var instructionSpan = instruction.AsSpan();
            var idx = instructionSpan.IndexOf(' ');

            var op = instructionSpan.Slice(0, idx);
            var offset = instructionSpan.Slice(idx + 1);

            if (MemoryExtensions.SequenceEqual(op, "nop"))
                result.op = Op.Nop;
            else if (MemoryExtensions.SequenceEqual(op, "acc"))
                result.op = Op.Acc;
            else if (MemoryExtensions.SequenceEqual(op, "jmp"))
                result.op = Op.Jmp;

            if (Int32.TryParse(offset, out var incr))
                result.offset = incr;

            return result;
        }
    }
}
