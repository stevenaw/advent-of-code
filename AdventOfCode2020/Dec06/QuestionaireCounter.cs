using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Dec06
{
    static class QuestionaireCounter
    {
        public static int CountDistinct(ref IEnumerator<string> fileEnumerator)
        {
            Span<bool> found = stackalloc bool[26];

            while (fileEnumerator.Current != string.Empty)
            {
                var line = fileEnumerator.Current;
                foreach (var c in line)
                {
                    var idx = c - 'a';
                    found[idx] = true;
                }

                if (!fileEnumerator.MoveNext())
                    break;
            }

            var count = 0;
            for (var i = 0; i < found.Length; i++)
                if (found[i])
                    count++;

            return count;
        }


        public static int CountWhereAllOccurences(ref IEnumerator<string> fileEnumerator)
        {
            Span<int> found = stackalloc int[26];
            var lineCount = 0;

            while (fileEnumerator.Current != string.Empty)
            {
                lineCount++;

                var line = fileEnumerator.Current;
                foreach (var c in line)
                {
                    var idx = c - 'a';
                    found[idx]++;
                }

                if (!fileEnumerator.MoveNext())
                    break;
            }

            var count = 0;
            for (var i = 0; i < found.Length; i++)
                if (found[i] == lineCount)
                    count++;

            return count;
        }
    }
}
