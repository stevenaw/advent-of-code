using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Dec07
{
    public static class BagHelper
    {
        public static int CountContainedBags(Dictionary<string, Dictionary<string, int>> graph, string nodeName)
        {
            var count = 0;

            if (graph.TryGetValue(nodeName, out var containedBags))
            {
                foreach (var kvp in containedBags)
                {
                    var bagType = kvp.Key;
                    var bagCount = kvp.Value;

                    var containedBagCount = CountContainedBags(graph, bagType);

                    count += bagCount;
                    count += bagCount * containedBagCount;
                }
            }

            return count;
        }

        public static List<string> GetContainingBagTypes(Dictionary<string, List<string>> graph, string nodeName)
        {
            var allBags = new List<string>();

            if (graph.TryGetValue(nodeName, out var bags))
            {
                foreach (var bag in bags)
                {
                    var containedBags = GetContainingBagTypes(graph, bag);

                    allBags.Add(bag);
                    allBags.AddRange(containedBags);
                }
            }

            return allBags;
        }

        public static Dictionary<string, List<string>> ParseBagsContainedBy(IEnumerable<string> lines)
        {
            var contained = BagHelper.ParseContainedBags(lines);
            var containedBy = BagHelper.InvertGraph(contained);
            return containedBy;
        }

        public static Dictionary<string, Dictionary<string, int>> ParseContainedBags(IEnumerable<string> lines)
        {
            var graph = new Dictionary<string, Dictionary<string, int>>();

            foreach (var line in lines)
            {
                var groups = line.Split(" contain ");
                var container = Regex.Replace(groups[0], " bags?$", "");

                var contained = new Dictionary<string, int>();
                if (groups[1] != "no other bags.")
                {
                    var tokens = groups[1].Split(", ");
                    for (var i = 0; i < tokens.Length; i++)
                    {
                        var firstSpace = tokens[i].IndexOf(' ');
                        var lastSpace = tokens[i].LastIndexOf(' ');

                        var quantity = tokens[i].Substring(0, firstSpace);
                        var containedItem = tokens[i].Substring(firstSpace + 1, lastSpace - firstSpace - 1);

                        contained[containedItem] = Int32.Parse(quantity);
                    }
                }

                graph[container] = contained;
            }

            return graph;
        }

        private static Dictionary<string, List<string>> InvertGraph(Dictionary<string, Dictionary<string, int>> contained)
        {
            var containedBy = new Dictionary<string, List<string>>();

            foreach (var kvp in contained)
            {
                var container = kvp.Key;
                var containedBags = kvp.Value.Keys;
                foreach (var containedBag in containedBags)
                {
                    if (!containedBy.ContainsKey(containedBag))
                        containedBy[containedBag] = new List<string>();

                    if (!containedBy[containedBag].Contains(container))
                        containedBy[containedBag].Add(container);
                }
            }

            return containedBy;
        }
    }
}
