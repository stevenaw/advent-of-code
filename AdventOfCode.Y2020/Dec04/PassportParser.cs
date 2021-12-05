using System.Collections.Generic;

namespace AdventOfCode.Y2020.Dec04
{
    public static class PassportParser
    {
        public static IEnumerable<Dictionary<string, string>> ParsePassports(IEnumerable<string> fileContents)
        {
            var enumerator = fileContents.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var passport = ParsePassport(ref enumerator);
                yield return passport;
            }
        }

        private static Dictionary<string, string> ParsePassport(ref IEnumerator<string> fileEnumerator)
        {
            var dict = new Dictionary<string, string>();

            while (fileEnumerator.Current != string.Empty)
            {
                var line = fileEnumerator.Current;

                var fields = line.Split(' ');
                foreach (var field in fields)
                {
                    var parts = field.Split(':');
                    dict[parts[0]] = parts[1];
                }

                if (!fileEnumerator.MoveNext())
                    break;
            }

            return dict;
        }
    }
}
