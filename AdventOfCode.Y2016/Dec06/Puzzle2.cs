namespace AdventOfCode.Y2016.Dec06
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            const int LettersPerWord = 8;
            const int LettersInAlphabet = 26;

            var letterCounts = new int[LettersPerWord * LettersInAlphabet];

            foreach (var line in lines)
            {
                for (var i = 0; i < LettersPerWord; i++)
                {
                    var letterIdx = line[i] - 'a';
                    letterCounts[i * LettersInAlphabet + letterIdx]++;
                }
            }

            Span<char> answer = stackalloc char[LettersPerWord];
            for (var i = 0; i < LettersPerWord; i++)
            {
                var lowestIdx = -1;
                for (var j = 0; j < LettersInAlphabet; j++)
                {
                    var candidate = letterCounts[i * LettersInAlphabet + j];
                    if (candidate == 0)
                        continue;

                    if (lowestIdx == -1)
                        lowestIdx = j;
                    else if (lowestIdx != -1 && letterCounts[i * LettersInAlphabet + lowestIdx] > candidate)
                        lowestIdx = j;
                }
                    
                var letter = (char)(lowestIdx + 'a');
                answer[i] = letter;
            }

            Console.WriteLine(answer.ToString());

            return TypeEncoder.EncodeAsLong(answer);
        }
    }
}
