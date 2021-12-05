namespace AdventOfCode.Y2020.Dec05
{
    static class BinaryTranslator
    {
        public static int CalculateIndex(string s)
        {
            int result = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == 'B' || s[i] == 'R')
                    result |= 1 << s.Length - 1 - i;
            }

            return result;
        }
    }
}
