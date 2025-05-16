using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Y2016.Dec10
{
    internal record class BotCommand(int BotId, int LowId, string LowType, int HighId, string HighType);

    internal class BotRunner
    {
        private readonly Dictionary<int, List<int>> bots = [];
        private readonly List<BotCommand> ops = [];

        public readonly Dictionary<int, int> Outputs = [];
        public readonly List<(int botId, int low, int high)> ComparisonHistory = [];

        public void ReceiveCommand(string line)
        {
            if (line.StartsWith("value"))
            {
                var match = Regex.Match(line, @"^value (\d+) goes to bot (\d+)$");
                var value = int.Parse(match.Groups[1].Value);
                var botId = int.Parse(match.Groups[2].Value);
                if (!bots.ContainsKey(botId))
                    bots[botId] = new List<int>();
                bots[botId].Add(value);
            }
            else if (line.StartsWith("bot"))
            {
                var match = Regex.Match(line, @"^bot (\d+) gives low to (bot|output) (\d+) and high to (bot|output) (\d+)$");

                var botId = int.Parse(match.Groups[1].Value);
                var lowType = match.Groups[2].Value;
                var lowId = int.Parse(match.Groups[3].Value);
                var highType = match.Groups[4].Value;
                var highId = int.Parse(match.Groups[5].Value);

                ops.Add(new BotCommand(botId, lowId, lowType, highId, highType));

                if (!bots.ContainsKey(botId))
                    bots[botId] = new List<int>();
                if (lowType == "bot" && !bots.ContainsKey(lowId))
                    bots[lowId] = new List<int>();
                if (highType == "bot" && !bots.ContainsKey(highId))
                    bots[highId] = new List<int>();
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

                        if (op.LowType == "bot")
                        {
                            bots[op.LowId].Add(lowValue);
                        }
                        if (op.HighType == "bot")
                        {
                            bots[op.HighId].Add(highValue);
                        }
                        if (op.LowType == "output")
                        {
                            Outputs[op.LowId] = lowValue;
                        }
                        if (op.HighType == "output")
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
    }
}
