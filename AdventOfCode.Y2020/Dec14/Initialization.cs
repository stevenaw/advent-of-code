namespace AdventOfCode.Y2020.Dec14
{
    class Initialization
    {
        public ulong Mask { get; set; }
        public ulong MaskOverrides { get; set; }
        public List<(ulong Address, ulong Value)> Assignments { get; set; }

        public static bool TryParse(ref IEnumerator<string> enumerator, out Initialization result)
        {
            ulong mask = 0L;
            ulong maskOverrides = 0L;
            var maskLine = enumerator.Current;

            if (string.IsNullOrEmpty(maskLine) || !maskLine.StartsWith("mask"))
            {
                result = null;
                return false;
            }

            var idx = 0;
            for (var i = maskLine.Length - 1; i >= 0 && maskLine[i] != ' '; i--)
            {
                if (maskLine[i] != 'X')
                    mask |= 1UL << idx;

                if (maskLine[i] == '1')
                    maskOverrides |= 1UL << idx;

                idx++;
            }

            var assignments = new List<(ulong Address, ulong Value)>();
            while (enumerator.MoveNext() && enumerator.Current.StartsWith("mem"))
            {
                var line = enumerator.Current.AsSpan();

                line = line.Slice(4);

                var addressIdx = line.IndexOf(']');
                var addressSpan = line.Slice(0, addressIdx);
                if (!ulong.TryParse(addressSpan, out var address))
                    address = 0;

                var valueIdx = line.LastIndexOf(' ');
                var valueSpan = line.Slice(valueIdx);
                if (!ulong.TryParse(valueSpan, out var value))
                    value = 0;

                assignments.Add((address, value));
            }

            result = new Initialization
            {
                Mask = mask,
                MaskOverrides = maskOverrides,
                Assignments = assignments
            };
            return true;
        }
    }
}
