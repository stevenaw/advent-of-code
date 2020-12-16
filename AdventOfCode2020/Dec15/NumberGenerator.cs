using System.Collections.Generic;

namespace AdventOfCode2020.Dec15
{
    class NumberGenerator
    {
        public static long GetNthNumber(IEnumerable<int> seed, int n)
        {
            const int PastIndexCount = 2;
            var history = new Dictionary<int, List<int>>();

            var i = 1;
            var prevNumber = 0;

            foreach (var item in seed)
            {
                history[item] = new List<int>(PastIndexCount) {
                    i++
                };
                prevNumber = item;
            }

            while (i <= n)
            {
                var prevOccurences = history[prevNumber];

                var nextNumber = 0;
                if (prevOccurences.Count != 1)
                {
                    nextNumber = prevOccurences[prevOccurences.Count - 1] - prevOccurences[prevOccurences.Count - 2];
                    prevOccurences.RemoveAt(0); // Keep the list size small
                }

                if (!history.ContainsKey(nextNumber))
                    history[nextNumber] = new List<int>(PastIndexCount);

                history[nextNumber].Add(i++);
                prevNumber = nextNumber;
            }

            return prevNumber;
        }
    }
}
