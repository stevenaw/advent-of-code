namespace AdventOfCode.Y2015.Dec07
{
    internal record Operation
    {
        public string Destination { get; init; }
        public string[] Args { get; set; }

        public Operation (string destination, string[] args)
        {
            Destination = destination;
            Args = args;
        }

        public static Operation Parse(string input)
        {
            var parts = input.Split(' ').AsSpan();
            var destination = parts[^1];
            var args = parts[0..^2].ToArray();

            return new Operation(destination, args);
        }
    }
}
