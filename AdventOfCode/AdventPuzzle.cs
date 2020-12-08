using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public abstract class AdventPuzzle
    {
        public long Solve() => Solve(GetDataFileContents());

        public IEnumerable<string> GetDataFileContents()
        {
            var day = GetType().Namespace.Split('.').Last();
            var fileName = $"./{day}/Data.txt";
            return File.ReadLines(fileName);
        }

        protected abstract long Solve(IEnumerable<string> lines);
    }
}
