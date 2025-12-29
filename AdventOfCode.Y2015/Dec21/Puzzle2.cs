namespace AdventOfCode.Y2015.Dec21
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var bossStats = Game.GetBossStats(lines);
            var maxCost = int.MinValue;

            foreach (var items in Game.EnumerateSetups())
            {
                var boss = bossStats.Clone();
                var player = Game.Entity.FromItems(items);

                if (!Game.DoesPlayerWin(player, boss))
                {
                    maxCost = Math.Max(maxCost, player.GearCost);
                }
            }

            return maxCost;
        }
    }
}
