using System.Text.RegularExpressions;

namespace AdventOfCode.Y2015.Dec16
{
    internal partial class Puzzle1 : AdventPuzzle
    {
        public enum Attributes
        {
            children = 0,
            cats,
            samoyeds,
            pomeranians,
            akitas,
            vizslas,
            goldfish,
            trees,
            cars,
            perfumes
        }

        protected override long Solve(IEnumerable<string> lines)
        {
            int[] neededAttributes = new int[10];

            neededAttributes[(int)Attributes.children] = 3;
            neededAttributes[(int)Attributes.cats] = 7;
            neededAttributes[(int)Attributes.samoyeds] = 2;
            neededAttributes[(int)Attributes.pomeranians] = 3;
            neededAttributes[(int)Attributes.akitas] = 0;
            neededAttributes[(int)Attributes.vizslas] = 0;
            neededAttributes[(int)Attributes.goldfish] = 5;
            neededAttributes[(int)Attributes.trees] = 3;
            neededAttributes[(int)Attributes.cars] = 2;
            neededAttributes[(int)Attributes.perfumes] = 1;

            foreach(var line in lines)
            {
                var parts = ParseLine().Match(line).Groups;

                var sueNumber = int.Parse(parts[1].ValueSpan);
                var animals = parts[3].Captures;
                var counts = parts[4].Captures;

                bool match = true;
                for (int i = 0; i < animals.Count; i++)
                {
                    var attribute = Enum.Parse<Attributes>(animals[i].ValueSpan);
                    var value = int.Parse(counts[i].ValueSpan);

                    if(IsNotSue(attribute, value))
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                    return sueNumber;
            }

            return 0;

            bool IsNotSue(Attributes attribute, int value)
            {
                return neededAttributes[(int)attribute] != value;
            }
        }

        [GeneratedRegex(@"^Sue (\d+): ((\w+): (\d+)(, )?)+")]
        private static partial Regex ParseLine();
    }
}
