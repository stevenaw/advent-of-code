namespace AdventOfCode.Y2015.Dec06
{
    internal ref struct Operation
    {
        public Coords Start { get; init; }
        public Coords End { get; init; }
        public OpCode OpCode { get; init; }

        public static Operation Parse(ReadOnlySpan<char> line)
        {
            OpCode opCode = default;
            var map = new Dictionary<string, OpCode>()
            {
                { "turn off", OpCode.Off },
                { "turn on", OpCode.On},
                { "toggle", OpCode.Toggle },
            };

            foreach (var item in map)
            {
                if (line.StartsWith(item.Key))
                {
                    opCode = item.Value;
                    line = line.Slice(item.Key.Length + 1);
                    break;
                }
            }

            var idx = line.IndexOf(' ');
            var start = Coords.Parse(line.Slice(0, idx));
            var end = Coords.Parse(line.Slice(idx + " through ".Length));

            return new Operation()
            {
                Start = start,
                End = end,
                OpCode = opCode
            };
        }
    }
}
