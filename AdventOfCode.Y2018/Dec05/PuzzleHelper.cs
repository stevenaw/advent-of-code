namespace AdventOfCode.Y2018.Dec05
{
    internal static class PuzzleHelper
    {
        internal static int Condense(Span<char> input)
        {
            const int diff = 'a' - 'A';

            // Use a portion of the input itself as the stack to avoid extra allocation
            var stackSize = 0;

            for (var i = 0; i < input.Length; i++)
            {
                // We can assume that the input is only ASCII letters,
                // so we can just check the difference between the two characters
                // to see if they are the same letter in different cases.
                if (stackSize > 0 && Math.Abs(input[stackSize - 1] - input[i]) == diff)
                {
                    stackSize--;
                }
                else
                {
                    input[stackSize++] = input[i];
                }
            }

            return stackSize;
        }


        //internal static int Condense(Span<char> input)
        //{
        //    int idx = -1;
        //    var startIdx = 0;

        //    const int diff = 'a' - 'A';

        //    do
        //    {
        //        idx = -1;
        //        for (int i = startIdx; i < input.Length - 1; i++)
        //        {
        //            if (Math.Abs(input[i] - input[i + 1]) == diff)
        //            {
        //                idx = i;
        //                break;
        //            }
        //        }

        //        if (idx != -1)
        //        {
        //            for (var i = idx; i < input.Length - 2; i++)
        //            {
        //                input[i] = input[i + 2];
        //            }

        //            input = input[..^2];
        //            startIdx = Math.Max(0, idx - 1);
        //        }
        //    }
        //    while (idx != -1);

        //    return input.Length;
        //}
    }
}
