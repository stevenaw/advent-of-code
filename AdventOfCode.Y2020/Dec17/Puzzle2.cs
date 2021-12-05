using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AdventOfCode.Y2020.Dec17
{
    class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var state = ParseInitialState(lines).ToArray();

            for (var gen = 1; gen <= 6; gen++)
            {
                int minX = int.MaxValue, minY = int.MaxValue, minZ = int.MaxValue, minW = int.MaxValue;
                int maxX = int.MinValue, maxY = int.MinValue, maxZ = int.MinValue, maxW = int.MinValue;

                var nextGen = new List<ConwayHyperCube>();

                foreach (var cube in state)
                {
                    minX = Math.Min(minX, cube.X);
                    minY = Math.Min(minY, cube.Y);
                    minZ = Math.Min(minZ, cube.Z);
                    minW = Math.Min(minW, cube.W);

                    maxX = Math.Max(maxX, cube.X);
                    maxY = Math.Max(maxY, cube.Y);
                    maxZ = Math.Max(maxZ, cube.Z);
                    maxW = Math.Max(maxW, cube.W);
                }

                for (var w = minW - 1; w <= maxW + 1; w++)
                {
                    for (var z = minZ - 1; z <= maxZ + 1; z++)
                    {
                        for (var y = minY - 1; y <= maxY + 1; y++)
                        {
                            for (var x = minX - 1; x <= maxX + 1; x++)
                            {
                                var occupied = state.Any(cube => cube.Equals(x, y, z, w));
                                var adjacent = state.Count(cube => cube.IsAdjacent(x, y, z, w));

                                var active = occupied ? adjacent == 2 || adjacent == 3 : adjacent == 3;

                                if (active)
                                {
                                    nextGen.Add(new ConwayHyperCube()
                                    {
                                        X = x,
                                        Y = y,
                                        Z = z,
                                        W = w
                                    });
                                }
                            }
                        }
                    }
                }


                state = nextGen.ToArray();
            }

            return state.Length;
        }

        private static List<ConwayHyperCube> ParseInitialState(IEnumerable<string> lines)
        {
            var data = lines.ToArray();
            var result = new List<ConwayHyperCube>();

            for (var y = 0; y < data.Length; y++)
            {
                for (var x = 0; x < data[y].Length; x++)
                {
                    if (data[y][x] == '#')
                        result.Add(new ConwayHyperCube()
                        {
                            X = x,
                            Y = data.Length - y - 1,
                            Z = 0,
                            W = 0
                        });
                }
            }

            return result;
        }

        [DebuggerDisplay("X={X},Y={Y},Z={Z},W={W}")]
        private class ConwayHyperCube : IEquatable<ConwayHyperCube>
        {
            public int X { get; init; }
            public int Y { get; init; }
            public int Z { get; init; }
            public int W { get; init; }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(ConwayHyperCube other) => Equals(other.X, other.Y, other.Z, other.W);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(int x, int y, int z, int w) => X == x && Y == y && Z == z && W == w;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool IsAdjacent(ConwayHyperCube other) => IsAdjacent(other.X, other.Y, other.Z, other.W);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool IsAdjacent(int x, int y, int z, int w)
            {
                return !Equals(x, y, z, w) && Math.Abs(X - x) < 2 && Math.Abs(Y - y) < 2 && Math.Abs(Z - z) < 2 && Math.Abs(W - w) < 2;
            }
        }
    }
}
