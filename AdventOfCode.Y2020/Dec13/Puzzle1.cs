namespace AdventOfCode.Y2020.Dec13
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var itinerary = ParseInput(lines);

            var firstDeparture = FindFirstDeparture(itinerary.minimumDeparture, itinerary.buses);
            var result = firstDeparture.bus * (firstDeparture.time - itinerary.minimumDeparture);

            return result;
        }

        private static (int bus, int time) FindFirstDeparture(int minimumDeparture, int[] buses)
        {
            for (var i = 0; i < buses[0]; i++)
            {
                var time = minimumDeparture + i;
                for (var j = 0; j < buses.Length; j++)
                    if (time % buses[j] == 0)
                        return (buses[j], time);
            }

            return (0, 0);
        }

        private static (int minimumDeparture, int[] buses) ParseInput(IEnumerable<string> lines)
        {
            var enumerator = lines.GetEnumerator();

            enumerator.MoveNext();
            var minimumDeparture = int.Parse(enumerator.Current);

            enumerator.MoveNext();

            var buses = new List<int>();
            var busesSpan = enumerator.Current.AsSpan();

            var nextDelim = busesSpan.IndexOf(',');
            while (!busesSpan.IsEmpty && nextDelim != -1)
            {
                var t = busesSpan.Slice(0, nextDelim);
                if (int.TryParse(t, out var num))
                    buses.Add(num);

                busesSpan = busesSpan.Slice(t.Length + 1);
                nextDelim = busesSpan.IndexOf(',');
            }

            if (int.TryParse(busesSpan, out var lastNum))
                buses.Add(lastNum);

            buses.Sort();

            return (minimumDeparture, buses.ToArray());
        }
    }
}
