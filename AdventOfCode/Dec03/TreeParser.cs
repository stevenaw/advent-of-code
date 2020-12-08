using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Dec03
{
    static class TreeParser
    {
        public static bool[][] ParseTrees(IEnumerable<string> fileContents)
        {
            return fileContents.Select(o => TreeParser.ParseTreeLine(o)).ToArray();
        }

        public static bool[] ParseTreeLine(string line)
        {
            const char TREE = '#';

            var treeLine = GC.AllocateUninitializedArray<bool>(line.Length);
            for (var i = 0; i < treeLine.Length; i++)
                treeLine[i] = line[i] == TREE;

            return treeLine;
        }
    }
}
