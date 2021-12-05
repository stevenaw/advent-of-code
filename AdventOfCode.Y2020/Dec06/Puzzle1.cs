namespace AdventOfCode.Y2020.Dec06
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var totalCount = 0L;
            var enumerator = lines.GetEnumerator();

            while (enumerator.MoveNext())
                totalCount += QuestionaireCounter.CountDistinct(ref enumerator);

            return totalCount;
        }
    }
}
