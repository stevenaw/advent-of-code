using System.Text.RegularExpressions;

namespace AdventOfCode.Y2016.Dec10
{
    internal enum ValueDestination
    {
        Bot,
        Output
    }

    internal record class BotCommand(int BotId, int LowId, ValueDestination LowType, int HighId, ValueDestination HighType);

    internal partial class BotRunner
    {
        private readonly Dictionary<int, List<int>> bots = [];
        private readonly List<BotCommand> ops = [];

        public Dictionary<int, int> Outputs { get; } = [];
        public List<(int botId, int low, int high)> ComparisonHistory { get; } = [];

        public void ReceiveCommands(IEnumerable<string> lines)
        {
            foreach(var line in lines)
            {
                if (line.StartsWith("value", StringComparison.Ordinal))
                {
                    var match = BotReceivesValueRegex().Match(line);
                    var value = int.Parse(match.Groups[1].Value);
                    var botId = int.Parse(match.Groups[2].Value);
                    if (!bots.ContainsKey(botId))
                        bots[botId] = new List<int>();
                    bots[botId].Add(value);
                }
                else if (line.StartsWith("bot", StringComparison.Ordinal))
                {
                    var match = BotGivesToBotRegex().Match(line);

                    var botId = int.Parse(match.Groups[1].Value);
                    var lowType = match.Groups[2].Value == "bot" ? ValueDestination.Bot : ValueDestination.Output;
                    var lowId = int.Parse(match.Groups[3].Value);
                    var highType = match.Groups[4].Value == "bot" ? ValueDestination.Bot : ValueDestination.Output;
                    var highId = int.Parse(match.Groups[5].Value);

                    ops.Add(new BotCommand(botId, lowId, lowType, highId, highType));

                    if (!bots.ContainsKey(botId))
                        bots[botId] = new List<int>();
                    if (lowType == ValueDestination.Bot && !bots.ContainsKey(lowId))
                        bots[lowId] = new List<int>();
                    if (highType == ValueDestination.Bot && !bots.ContainsKey(highId))
                        bots[highId] = new List<int>();
                }
            }
        }

        public void Process()
        {
            while (ops.Count > 0)
            {
                for (var i = 0; i < ops.Count; i++)
                {
                    var op = ops[i];
                    if (bots[op.BotId].Count == 2)
                    {
                        bots[op.BotId].Sort();
                        var lowValue = bots[op.BotId][0];
                        var highValue = bots[op.BotId][1];

                        ComparisonHistory.Add((op.BotId, lowValue, highValue));

                        if (op.LowType == ValueDestination.Bot)
                        {
                            bots[op.LowId].Add(lowValue);
                        }
                        if (op.HighType == ValueDestination.Bot)
                        {
                            bots[op.HighId].Add(highValue);
                        }
                        if (op.LowType == ValueDestination.Output)
                        {
                            Outputs[op.LowId] = lowValue;
                        }
                        if (op.HighType == ValueDestination.Output)
                        {
                            Outputs[op.HighId] = highValue;
                        }
                        ops.RemoveAt(i);
                        i--;

                        bots[op.BotId].Clear();
                    }
                }
            }
        }

        [GeneratedRegex(@"^bot (\d+) gives low to (bot|output) (\d+) and high to (bot|output) (\d+)$")]
        internal static partial Regex BotGivesToBotRegex();

        [GeneratedRegex(@"^value (\d+) goes to bot (\d+)$")]
        internal static partial Regex BotReceivesValueRegex();
    }
}
