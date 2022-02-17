namespace AdventOfCode.Y2015.Dec04
{
    internal class HashFinder
    {
        private readonly string _seed;

        public HashFinder(string seed)
        {
            _seed = seed;
        }

        public int GetHashStartsWith(string startsWith)
        {
            for (var i = 0; i < int.MaxValue; i++)
            {
                var str = Hasher.HashAsHexString(_seed, i);
                if (str.StartsWith(startsWith))
                    return i;
            }

            return -1;
        }
    }
}
