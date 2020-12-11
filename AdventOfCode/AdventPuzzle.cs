using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2020
{
    public abstract class AdventPuzzle
    {
        public static AdventPuzzle GetPuzzle(int day, int puzzleNumber)
        {
            var typeName = $"{typeof(AdventPuzzle).Namespace}.Dec{day:00}.Puzzle{puzzleNumber}";
            var type = Assembly.GetExecutingAssembly().GetType(typeName);

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
