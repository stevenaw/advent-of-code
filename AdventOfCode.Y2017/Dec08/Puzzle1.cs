using System.Runtime.InteropServices;

namespace AdventOfCode.Y2017.Dec08
{
    internal class Puzzle1 : AdventPuzzle
    {
        private static readonly Dictionary<string, int> registers = new ();
        private static readonly Dictionary<string, int>.AlternateLookup<ReadOnlySpan<char>> registersLookup = registers.GetAlternateLookup<ReadOnlySpan<char>>();

        protected override long Solve(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var s = line.AsSpan();

                // g dec 231 if bfx > -10
                var idx = s.LastIndexOf(' ');
                var amount = s.Slice(idx+1);

                s = s.Slice(0, idx);
                idx = s.LastIndexOf(' ');
                var op = s.Slice(idx+1);

                s = s.Slice(0, idx);
                idx = s.LastIndexOf(' ');
                var register = s.Slice(idx+1);

                if (EvaluateExpression(register, op, amount) == 0)
                    continue;

                // g dec 231 if bfx > -10
                idx = s.IndexOf(' ');
                register = s[..idx];

                s = s.Slice(idx + 1);
                idx = s.IndexOf(' ');
                op = s[..idx];

                s = s.Slice(idx + 1);
                idx = s.IndexOf(' ');
                amount = s[..idx];

                EvaluateExpression(register, op, amount);
            }


            return registers.Values.Max();



            static int EvaluateExpression(ReadOnlySpan<char> register, ReadOnlySpan<char> op, ReadOnlySpan<char> rValue)
            {
                int.TryParse(rValue, out var amountValue);
                ref var registerValue = ref CollectionsMarshal.GetValueRefOrAddDefault(registersLookup, register, out _);

                switch (op)
                {
                    case ">":
                        return registerValue > amountValue ? 1 : 0;
                    case ">=":
                        return registerValue >= amountValue ? 1 : 0;
                    case "<":
                        return registerValue < amountValue ? 1 : 0;
                    case "<=":
                        return registerValue <= amountValue ? 1 : 0;
                    case "!=":
                        return registerValue != amountValue ? 1 : 0;
                    case "==":
                        return registerValue == amountValue ? 1 : 0;


                    case "inc":
                        registersLookup[register] = registerValue + amountValue;
                        return registerValue + amountValue;

                    case "dec":
                        registersLookup[register] = registerValue - amountValue;
                        return registerValue - amountValue;
                }

                Console.WriteLine("Unexpected operator " + op.ToString());
                return 0;
            }
        }
    }
}
