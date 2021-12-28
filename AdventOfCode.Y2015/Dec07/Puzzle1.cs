namespace AdventOfCode.Y2015.Dec07
{
    internal class Puzzle1 : AdventPuzzle
    {
        private static readonly Dictionary<string, ushort> knownValues = new Dictionary<string, ushort>();

        protected override long Solve(IEnumerable<string> lines)
        {
            var inputs = lines.Select(ParseLine).ToDictionary(o => o.Destination, o => o);
            return GetValue("a", inputs);
        }

        private static Operation ParseLine(string line)
        {
            var parts = line.Split(' ').AsSpan();
            var destination = parts[^1];
            var args = parts[0..^2].ToArray();

            return new Operation(destination, args);
        }

        private static ushort GetValue(string name, Dictionary<string, Operation> allOperations)
        {
            ushort value;
            if (knownValues.TryGetValue(name, out value))
                return value;

            var op = allOperations[name];
            if (op.Args.Length == 1)
                value = ResolveIdentifierValue(op.Args[0], allOperations);
            else
            {
                var opCode = op.Args[^2];
                var rHand = op.Args[^1];
                var lHand = op.Args.Length > 2 ? op.Args[^3] : null;

                if (opCode == "NOT")
                    value = (ushort)~ResolveIdentifierValue(rHand, allOperations);
                else if (opCode == "AND")
                    value = (ushort)(ResolveIdentifierValue(lHand, allOperations) & ResolveIdentifierValue(rHand, allOperations));
                else if (opCode == "OR")
                    value = (ushort)(ResolveIdentifierValue(lHand, allOperations) | ResolveIdentifierValue(rHand, allOperations));
                else if (opCode == "LSHIFT")
                    value = (ushort)(ResolveIdentifierValue(lHand, allOperations) << ResolveIdentifierValue(rHand, allOperations));
                else if (opCode == "RSHIFT")
                    value = (ushort)(ResolveIdentifierValue(lHand, allOperations) >> ResolveIdentifierValue(rHand, allOperations));
            }

            knownValues[name] = value;
            return value;

            static ushort ResolveIdentifierValue(string value, Dictionary<string, Operation> allOperations)
            {
                if (ushort.TryParse(value, out var v))
                    return v;
                return GetValue(value, allOperations);
            }
        }
    }

    record Operation (string Destination, string[] Args);
}
