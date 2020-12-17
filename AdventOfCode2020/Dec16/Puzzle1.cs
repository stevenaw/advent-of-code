using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Dec16
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var enumerator = lines.GetEnumerator();

            var options = Parser.ParseFuzzyMatches(enumerator);
            var nearbyTickets = Parser.ParseTickets(enumerator).Skip(1).ToList();

            var invalidNumberSum = 0;
            foreach(var ticket in nearbyTickets)
            {
                var invalidFields = ticket.Where(o => !options.Any(opt => opt.Possibilities.Any(p => o >= p.min && o <= p.max)));
                invalidNumberSum += invalidFields.Sum();
            }

            return invalidNumberSum;
        }
    }
}
