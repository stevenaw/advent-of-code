using System.Reflection;

namespace AdventOfCode
{
    public abstract class AdventPuzzle : AdventPuzzle<long>
    {
        public static TResult Solve<TResult>(int year, int day, int puzzleNumber)
        {
            var puzzle = GetPuzzle<TResult>(year, day, puzzleNumber);
            var result = puzzle.Solve();
            return result;
        }

        public static string Solve(int year, int day, int puzzleNumber)
        {
            var type = GetPuzzleType(year, day, puzzleNumber);
            var method = type.GetMethod(nameof(AdventPuzzle.Solve),
                BindingFlags.NonPublic | BindingFlags.Instance,
                []);

            var puzzle = Activator.CreateInstance(type);
            var result = method!.Invoke(puzzle, null);

            return result?.ToString() ?? "";
        }

        private static Type GetPuzzleType(int year, int day, int puzzleNumber)
        {
            var assemblyName = $"{typeof(AdventPuzzle).Namespace}.Y{year}";
            var typeName = $"{assemblyName}.Dec{day:00}.Puzzle{puzzleNumber}";

            var qualifiedName = Assembly.CreateQualifiedName(assemblyName, typeName);
            var type = Type.GetType(qualifiedName);
            if (type is null)
                throw new InvalidOperationException("Could not find the puzzle type");

            return type;
        }

        private static AdventPuzzle<TResult> GetPuzzle<TResult>(int year, int day, int puzzleNumber)
        {
            var type = GetPuzzleType(year, day, puzzleNumber);

            var puzzle = Activator.CreateInstance(type);
            if (puzzle is null)
                throw new InvalidOperationException("Could not create the puzzle");

            return (AdventPuzzle<TResult>)puzzle;
        }

    }

    public abstract class AdventPuzzle<TResult>
    {
        protected abstract TResult Solve(IEnumerable<string> lines);

        internal TResult Solve()
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
                chars = chars[1..];

            var eol = Environment.NewLine;
            var nextDelim = chars.IndexOf(eol);

            var lines = new List<string>();
            while (!chars.IsEmpty && nextDelim != -1)
            {
                var t = chars[..nextDelim];
                lines.Add(t.ToString());

                chars = chars[(t.Length + eol.Length)..];
                nextDelim = chars.IndexOf(eol);
            }

            if (!chars.IsEmpty)
                lines.Add(chars.ToString());

            return lines;
        }
    }
}
