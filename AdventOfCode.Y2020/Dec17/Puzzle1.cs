using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AdventOfCode.Y2020.Dec17
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var state = ParseInitialState(lines);

            for (var gen = 1; gen <= 6; gen++)
            {
                int minX = int.MaxValue, minY = int.MaxValue, minZ = int.MaxValue;
                int maxX = int.MinValue, maxY = int.MinValue, maxZ = int.MinValue;
                var nextGen = new List<ConwayCube>();

                foreach (var cube in state)
                {
                    minX = Math.Min(minX, cube.X);
                    minY = Math.Min(minY, cube.Y);
                    minZ = Math.Min(minZ, cube.Z);

                    maxX = Math.Max(maxX, cube.X);
                    maxY = Math.Max(maxY, cube.Y);
                    maxZ = Math.Max(maxZ, cube.Z);
                }

                for (var z = minZ - 1; z <= maxZ + 1; z++)
                {
                    for (var y = minY - 1; y <= maxY + 1; y++)
                    {
                        for (var x = minX - 1; x <= maxX + 1; x++)
                        {
                            var occupied = state.Any(cube => cube.Equals(x, y, z));
                            var adjacent = state.Count(cube => cube.IsAdjacent(x, y, z));

                            var active = occupied ? adjacent == 2 || adjacent == 3 : adjacent == 3;

                            if (active)
                            {
                                nextGen.Add(new ConwayCube()
                                {
                                    X = x,
                                    Y = y,
                                    Z = z
                                });
                            }
                        }
                    }
                }

                state = nextGen;
            }

            return state.Count;
        }

        private static List<ConwayCube> ParseInitialState(IEnumerable<string> lines)
        {
            var data = lines.ToArray();
            var result = new List<ConwayCube>();

            for (var y = 0; y < data.Length; y++)
            {
                for (var x = 0; x < data[y].Length; x++)
                {
                    if (data[y][x] == '#')
                        result.Add(new ConwayCube()
                        {
                            X = x,
                            Y = data.Length - y - 1,
                            Z = 0
                        });
                }
            }

            return result;
        }

        [DebuggerDisplay("X={X},Y={Y},Z={Z}")]
        private class ConwayCube : IEquatable<ConwayCube>
        {
            public int X { get; init; }
            public int Y { get; init; }
            public int Z { get; init; }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(ConwayCube other) => Equals(other.X, other.Y, other.Z);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(int x, int y, int z) => X == x && Y == y && Z == z;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool IsAdjacent(ConwayCube other) => IsAdjacent(other.X, other.Y, other.Z);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool IsAdjacent(int x, int y, int z)
            {
                return !Equals(x, y, z) && Math.Abs(X - x) < 2 && Math.Abs(Y - y) < 2 && Math.Abs(Z - z) < 2;
            }
        }
    }
}
