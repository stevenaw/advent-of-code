namespace AdventOfCode.Y2017.Dec08
{
    internal class Puzzle1 : AdventPuzzle
    {
        static Dictionary<string, int> registers = new ();
        static Dictionary<string, int>.AlternateLookup<ReadOnlySpan<char>> registersLookup = registers.GetAlternateLookup<ReadOnlySpan<char>>();

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


                int.TryParse(amount, out var amountValue);
                if (!registersLookup.TryGetValue(register, out var registerValue))
                {
                    registersLookup[register] = registerValue = 0;
                }


                if (!CheckCondition(registerValue, op, amountValue))
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


                int.TryParse(amount, out amountValue);
                if (!registersLookup.TryGetValue(register, out registerValue))
                {
                    registersLookup[register] = registerValue = 0;
                }

                switch (op)
                {
                    case "inc":
                        registersLookup[register] = registerValue + amountValue;
                        break;

                    case "dec":
                        registersLookup[register] = registerValue - amountValue;
                        break;
                }
            }


            return registers.Values.Max();



            static bool CheckCondition(int a, ReadOnlySpan<char> op, int b)
            {
                switch (op)
                {
                    case ">":
                        return a > b;
                    case ">=":
                        return a >= b;
                    case "<":
                        return a < b;
                    case "<=":
                        return a <= b;
                    case "!=":
                        return a != b;
                    case "==":
                        return a == b;
                }

                Console.WriteLine("Unexpected operator " + op.ToString());
                return false;
            }
        }
    }
}
