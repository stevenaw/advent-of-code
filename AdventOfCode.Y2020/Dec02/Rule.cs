namespace AdventOfCode.Y2020.Dec02
{
    struct Rule
    {
        public int Minimum;
        public int Maximum;
        public char Character;
        public string Password;

        public static Rule Parse(string s)
        {
            var result = new Rule();

            var sp = s.AsSpan();

            var sep = sp.IndexOf('-');
            var token = sp.Slice(0, sep);
            result.Minimum = int.Parse(token);

            sp = sp.Slice(sep + 1);
            sep = sp.IndexOf(' ');
            token = sp.Slice(0, sep);
            result.Maximum = int.Parse(token);

            sp = sp.Slice(sep + 1);
            result.Character = sp[0];

            sep = sp.IndexOf(' ');
            token = sp.Slice(sep + 1);
            result.Password = token.ToString();

            return result;
        }
    }
}
