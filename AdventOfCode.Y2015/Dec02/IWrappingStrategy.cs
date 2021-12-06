namespace AdventOfCode.Y2015.Dec02
{
    internal interface IWrappingStrategy
    {
        long Calculate(Dimensions dim);
    }

    internal class PaperWrappingStrategy : IWrappingStrategy
    {
        public long Calculate(Dimensions dim)
        {
            var a = dim.Length * dim.Width;
            var b = dim.Width * dim.Height;
            var c = dim.Height * dim.Length;

            var extra = Math.Min(a, Math.Min(b, c));

            return 2 * a + 2 * b + 2 * c + extra;
        }
    }

    internal class RibbonWrappingStrategy : IWrappingStrategy
    {
        public long Calculate(Dimensions dim)
        {
            var a = 2 * (dim.Length + dim.Width);
            var b = 2 * (dim.Width + dim.Height);
            var c = 2 * (dim.Height + dim.Length);

            var smallestFace = Math.Min(a, Math.Min(b, c));
            var bow = dim.Length * dim.Width * dim.Height;

            return smallestFace + bow;
        }
    }
}
