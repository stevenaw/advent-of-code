namespace AdventOfCode.Y2020.Dec14
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var enumerator = lines.GetEnumerator();
            var memory = new Dictionary<ulong, ulong>();

            enumerator.MoveNext();
            while (Initialization.TryParse(ref enumerator, out var initialization))
            {
                foreach (var assignment in initialization.Assignments)
                    foreach (var address in EnumerateAddresses(assignment.Address, initialization))
                        memory[address] = assignment.Value;
            }

            var overrideSum = 0UL;
            foreach (var kvp in memory)
                overrideSum += kvp.Value;

            return (long)overrideSum;
        }

        private static List<ulong> EnumerateAddresses(ulong address, Initialization initialization)
        {
            const ulong BitsWeCareAbout = 0x0000000FFFFFFFFF;

            var wildcardMask = BitsWeCareAbout & ~initialization.Mask;
            var explicitBits = BitsWeCareAbout &
                                (initialization.MaskOverrides | ~(initialization.Mask & ~initialization.MaskOverrides));
            var explicitMasked = address | explicitBits;

            // 1. Seed seive 'list' with 'explicitMasked' (all wildcard bits are 'on')
            // 2.   Foreach wilcard index
            //          Foreach entry in 'list'
            //              Flip wildcard bit off and add

            var list = new List<ulong>();
            list.Add(explicitMasked);

            for (var i = 0; i < 36; i++)
            {
                var wildcardBit = 1UL << i;
                if ((wildcardMask & wildcardBit) != 0)
                {
                    var newAddresses = new ulong[list.Count];

                    var j = 0;
                    foreach (var item in list)
                        newAddresses[j++] = item & ~wildcardBit;

                    list.AddRange(newAddresses);
                }
            }

            return list;
        }
    }
}
