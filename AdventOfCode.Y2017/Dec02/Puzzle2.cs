namespace AdventOfCode.Y2017.Dec02
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0L;

            foreach (var line in lines)
            {
                var ids = ParsingHelpers.ParseIntegers(line, '\t');
                ids.Sort();

                var factor = 0;

                for (var i = 0; i < ids.Count - 1 && factor == 0; i++)
                {
                    for (var j = ids.Count - 1; j > i && factor == 0; j--)
                    {
                        if (TryEvenlyDivide(ids[j], ids[i], out var result))
                            factor = result;
                    }
                }

                sum += factor;
            }

            return sum;

            static bool TryEvenlyDivide(int dividend, int divisor, out int result)
            {
                var val = Math.DivRem(dividend, divisor, out var rem);
                if (rem == 0)
                {
                    result = val;
                    return true;
                }

                result = default;
                return false;
            }
        }
    }
}
