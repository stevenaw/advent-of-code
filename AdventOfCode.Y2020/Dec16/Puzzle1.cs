namespace AdventOfCode.Y2020.Dec16
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var enumerator = lines.GetEnumerator();

            var options = Parser.ParseFuzzyMatches(enumerator);
            var nearbyTickets = Parser.ParseTickets(enumerator).Skip(1).ToList();

            var invalidNumberSum = 0;
            foreach (var ticket in nearbyTickets)
            {
                var invalidFields = ticket.Where(o => !options.Any(opt => opt.Possibilities.Any(p => p.IsInRange(o))));
                invalidNumberSum += invalidFields.Sum();
            }

            return invalidNumberSum;
        }
    }
}
