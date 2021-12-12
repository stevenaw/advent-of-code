namespace AdventOfCode.Y2015.Dec06
{
    internal ref struct Operation
    {
        public Coords Start { get; init; }
        public Coords End { get; init; }
        public Action Action { get; init; }

        public static Operation Parse(ReadOnlySpan<char> line)
        {
            Action action = default;
            var map = new Dictionary<string, Action>()
                {
                    { "turn off", Action.Off },
                    { "turn on", Action.On},
                    { "toggle", Action.Toggle },
                };

            foreach (var item in map)
            {
                if (line.StartsWith(item.Key))
                {
                    action = item.Value;
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
                Action = action
            };
        }
    }
}
