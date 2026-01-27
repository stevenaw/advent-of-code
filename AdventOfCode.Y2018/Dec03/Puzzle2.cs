using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Y2018.Dec03
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var claims = lines.Select(Claim.ParseClaim).ToList();

            for (var i = 0; i < claims.Count; i++)
            {
                var doesOverlap = false;

                for (var j = 0; j < claims.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    if (claims[i].DoesOverlap(claims[j]))
                    {
                        doesOverlap = true;
                        break;
                    }
                }

                if (!doesOverlap)
                {
                    return claims[i].id;
                }
            }

            return 0;
        }
    }
}
