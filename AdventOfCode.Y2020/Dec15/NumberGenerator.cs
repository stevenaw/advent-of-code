namespace AdventOfCode.Y2020.Dec15
{
    class NumberGenerator
    {
        public static long GetNthNumber(IEnumerable<int> seed, int n)
        {
            const int PastIndexCount = 2;
            var history = new Dictionary<int, CircularBuffer<int>>();

            var i = 1;
            var prevNumber = 0;

            foreach (var item in seed)
            {
                var historyEntry = new CircularBuffer<int>(PastIndexCount);
                historyEntry.Add(i++);

                history[item] = historyEntry;
                prevNumber = item;
            }

            while (i <= n)
            {
                var prevOccurences = history[prevNumber];

                var nextNumber = 0;
                if (prevOccurences.Count != 1)
                    nextNumber = prevOccurences[0] - prevOccurences[1];

                CircularBuffer<int> historyEntry;
                if (!history.TryGetValue(nextNumber, out historyEntry))
                    historyEntry = new CircularBuffer<int>(PastIndexCount);

                historyEntry.Add(i++);
                history[nextNumber] = historyEntry;
                prevNumber = nextNumber;
            }

            return prevNumber;
        }
    }
}
