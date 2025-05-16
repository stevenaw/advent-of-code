namespace AdventOfCode.Y2016.Dec10
{
    internal class Puzzle2 : AdventPuzzle
    {
        private readonly Dictionary<int, List<int>> bots = [];

        private record class BotCommand(int BotId, int LowId, string LowType, int HighId, string HighType);

        protected override long Solve(IEnumerable<string> lines)
        {
            var runner = new BotRunner();

            runner.ReceiveCommands(lines);
            runner.Process();

            return runner.Outputs[0] * runner.Outputs[1] * runner.Outputs[2];
        }
    }
}
