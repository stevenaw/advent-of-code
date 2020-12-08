using System;
using System.Reflection;

namespace AdventOfCode2020
{
    public static class AdventPuzzleHelper
    {
        public static AdventPuzzle GetPuzzle(int day, int puzzleNumber)
        {
            var typeName = $"{typeof(AdventPuzzleHelper).Namespace}.Dec{day:00}.Puzzle{puzzleNumber}";
            var type = Assembly.GetExecutingAssembly().GetType(typeName);

            var puzzle = Activator.CreateInstance(type);

            return (AdventPuzzle)puzzle;
        }
    }
}
