namespace AdventOfCode.Y2018.Dec03
{
    internal record struct Claim(int id, int left, int top, int width, int height)
    {
        public static Claim ParseClaim(string input)
        {
            // #123 @ 3,2: 5x4
            var parts = input.Split(' ');
            var positionParts = parts[2].TrimEnd(':').Split(',');
            var sizeParts = parts[3].Split('x');

            var id = int.Parse(parts[0].AsSpan(1));
            var left = int.Parse(positionParts[0]);
            var top = int.Parse(positionParts[1]);
            var width = int.Parse(sizeParts[0]);
            var height = int.Parse(sizeParts[1]);
            return new (id, left, top, width, height);
        }

        public bool DoesOverlap(Claim other)
        {
            return !(left + width <= other.left ||
                     other.left + other.width <= left ||
                     top + height <= other.top ||
                     other.top + other.height <= top);
        }
    }
}
