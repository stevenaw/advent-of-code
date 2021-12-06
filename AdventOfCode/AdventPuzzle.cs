using System.Reflection;
using System.Runtime.CompilerServices;

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
            var data = asm.GetManifestResourceStream($"{ns}.Data.txt")!;

            var lines = EnumerateLines(data);
            return Solve(lines);
        }

        private static IEnumerable<string> EnumerateLines(Stream data)
        {
            // TODO: Not make a million little strings.
            // Consider if we can use UnmanagedMemoryStream

            using var reader = new StreamReader(data);
            while (!reader.EndOfStream)
                yield return reader.ReadLine()!;
        }

        protected abstract long Solve(IEnumerable<string> lines);
    }
}
