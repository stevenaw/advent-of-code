using System.Reflection;

namespace AdventOfCode
{
    public abstract class AdventPuzzle
    {
        public static AdventPuzzle GetPuzzle(int year, int day, int puzzleNumber)
        {
            var assemblyName = $"{typeof(AdventPuzzle).Namespace}.Y{year}";
            var typeName = $"{assemblyName}.Dec{day:00}.Puzzle{puzzleNumber}";

            var asm = Assembly.Load(assemblyName);
            if (asm is null)
                throw new InvalidOperationException("Could not find the assembly");

            var type = asm.GetType(typeName);
            if (type is null)
                throw new InvalidOperationException("Could not find the puzzle type");

            var puzzle = Activator.CreateInstance(type);
            if (puzzle is null)
                throw new InvalidOperationException("Could not create the puzzle");

            return (AdventPuzzle)puzzle;
        }

        public long Solve()
        {
            var ns = GetType().Namespace!;
            var asm = GetType().Assembly;
            using var data = asm.GetManifestResourceStream($"{ns}.Data.txt")!;

            var lines = ReadLines(data as UnmanagedMemoryStream);

            return Solve(lines);
        }

        private static unsafe IEnumerable<string> ReadLines(UnmanagedMemoryStream? data)
        {
            ArgumentNullException.ThrowIfNull(data);

            var chars = System.Text.Encoding.Default.GetString(data.PositionPointer, (int)data.Length).AsSpan();

            // Remove 0-width line break from start
            if (chars[0] == 65279)
                chars = chars.Slice(1);

            var eol = Environment.NewLine;
            var nextDelim = chars.IndexOf(eol);

            var lines = new List<string>();
            while (!chars.IsEmpty && nextDelim != -1)
            {
                var t = chars.Slice(0, nextDelim);
                lines.Add(t.ToString());

                chars = chars.Slice(t.Length + eol.Length);
                nextDelim = chars.IndexOf(eol);
            }

            if (!chars.IsEmpty)
                lines.Add(chars.ToString());

            return lines;
        }

        protected abstract long Solve(IEnumerable<string> lines);
    }
}
