using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var type = asm.GetType(typeName);
            var puzzle = Activator.CreateInstance(type);

            return (AdventPuzzle)puzzle;
        }

        public long Solve()
        {
            var day = GetType().Namespace.Split('.').Last();
            var fileName = $"./{day}/Data.txt";
            return Solve(File.ReadLines(fileName));
        }

        protected abstract long Solve(IEnumerable<string> lines);
    }
}
