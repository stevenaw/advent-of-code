using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Y2020.Dec16
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var enumerator = lines.GetEnumerator();

            var options = Parser.ParseFuzzyMatches(enumerator);
            var tickets = Parser.ParseTickets(enumerator).ToList();

            var myTicket = tickets.First();
            var validTickets = tickets.Skip(1).Where(t => t.All(o => options.Any(opt => opt.Possibilities.Any(p => p.IsInRange(o))))).ToList();



            // TODO:
            //  let foundMatches = [];
            //
            //  Foreach idx in unknownMatches
            //    Check field[idx] in all valid tickets against all options. Track which options would satisfy
            //    if field[idx] is satisfied by same option in all tickets
            //      add to foundMatches
            //
            //  Remove foundMatches from unknownMatches
            //  Add foundMatches to ??
            var foundMatches = new FuzzyFieldMatch[options.Count];
            var hasFoundNewMatches = true;
            while (options.Any() && hasFoundNewMatches)
            {
                foreach (var option in options)
                {
                    var matchIdxes = TryFindSingleMatch(option, validTickets, foundMatches);
                    if (matchIdxes.Count == 1)
                        foundMatches[matchIdxes.Single()] = option;
                }

                var removed = options.RemoveAll(o => foundMatches.Contains(o));
                hasFoundNewMatches = removed > 0;
            }

            var departureSum = 1L;
            for (var i = 0; i < foundMatches.Length; i++)
            {
                if (foundMatches[i].Name.StartsWith("departure"))
                {
                    departureSum *= myTicket[i];
                }
            }

            return departureSum;
        }

        private static List<int> TryFindSingleMatch(FuzzyFieldMatch option, List<List<int>> validTickets, FuzzyFieldMatch[] knownMatches)
        {
            var allMatches = new List<int>();

            for (var i = 0; i < validTickets[0].Count; i++)
            {
                if (knownMatches[i] != null)
                    continue;

                bool matchesForAllTickets = true;
                for (var j = 0; j < validTickets.Count && matchesForAllTickets; j++)
                {
                    // Check if 'option' is valid for all tickets at field 'i'
                    matchesForAllTickets = option.Possibilities.Any(opt => opt.IsInRange(validTickets[j][i]));
                }

                if (matchesForAllTickets)
                    allMatches.Add(i);
            }

            return allMatches;
        }
    }
}
