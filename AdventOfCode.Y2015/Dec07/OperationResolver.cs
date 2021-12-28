namespace AdventOfCode.Y2015.Dec07
{
    internal static class OperationResolver
    {
        public static ushort GetValue(string name, IEnumerable<Operation> ops)
            => GetValue(name, ops.ToDictionary(o => o.Destination, o => o), new());

        private static ushort GetValue(string name, Dictionary<string, Operation> allOperations, Dictionary<string, ushort> knownValues)
        {
            if (knownValues.TryGetValue(name, out var value))
                return value;

            var op = allOperations[name];
            if (op.Args.Length == 1)
                value = ResolveIdentifierValue(op.Args[0], allOperations, knownValues);
            else
            {
                var opCode = op.Args[^2];
                var rHand = op.Args[^1];
                var lHand = op.Args.Length > 2 ? op.Args[^3] : null;

                if (opCode == "NOT")
                    value = (ushort)~ResolveIdentifierValue(rHand, allOperations, knownValues);
                else if (opCode == "AND")
                    value = (ushort)(ResolveIdentifierValue(lHand!, allOperations, knownValues) & ResolveIdentifierValue(rHand, allOperations, knownValues));
                else if (opCode == "OR")
                    value = (ushort)(ResolveIdentifierValue(lHand!, allOperations, knownValues) | ResolveIdentifierValue(rHand, allOperations, knownValues));
                else if (opCode == "LSHIFT")
                    value = (ushort)(ResolveIdentifierValue(lHand!, allOperations, knownValues) << ResolveIdentifierValue(rHand, allOperations, knownValues));
                else if (opCode == "RSHIFT")
                    value = (ushort)(ResolveIdentifierValue(lHand!, allOperations, knownValues) >> ResolveIdentifierValue(rHand, allOperations, knownValues));
            }

            knownValues[name] = value;
            return value;

            static ushort ResolveIdentifierValue(string value, Dictionary<string, Operation> allOperations, Dictionary<string, ushort> knownValues)
            {
                if (ushort.TryParse(value, out var v))
                    return v;
                return GetValue(value, allOperations, knownValues);
            }
        }
    }
}
