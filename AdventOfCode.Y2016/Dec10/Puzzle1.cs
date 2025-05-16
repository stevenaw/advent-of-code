namespace AdventOfCode.Y2016.Dec10
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var runner = new BotRunner();

            runner.ReceiveCommands(lines);
            runner.Process();

            var comparison = runner.ComparisonHistory.FirstOrDefault(x => x.low == 17 && x.high == 61);
            return comparison.botId;
        }
    }
}
