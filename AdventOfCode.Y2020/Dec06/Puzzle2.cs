using System.Collections.Generic;

namespace AdventOfCode.Y2020.Dec06
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var totalCount = 0L;
            var enumerator = lines.GetEnumerator();

            while (enumerator.MoveNext())
                totalCount += QuestionaireCounter.CountWhereAllOccurences(ref enumerator);

            return totalCount;
        }
    }
}
