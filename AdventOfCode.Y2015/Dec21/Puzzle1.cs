
using System.Diagnostics;

namespace AdventOfCode.Y2015.Dec21
{
    internal class Puzzle1 : AdventPuzzle
    {
        const int PlayerHealth = 100;

        public static readonly Item[] ShopItems = [
            new Item { Type = ItemType.Weapon, Name = "Dagger", Cost = 8, Damage = 4, Armor = 0 },
            new Item { Type = ItemType.Weapon, Name = "Shortsword", Cost = 10, Damage = 5, Armor = 0 },
            new Item { Type = ItemType.Weapon, Name = "Warhammer", Cost = 25, Damage = 6, Armor = 0 },
            new Item { Type = ItemType.Weapon, Name = "Longsword", Cost = 40, Damage = 7, Armor = 0 },
            new Item { Type = ItemType.Weapon, Name = "Greataxe", Cost = 74, Damage = 8, Armor = 0 },
            new Item { Type = ItemType.Armor, Name = "Leather", Cost = 13, Damage = 0, Armor = 1 },
            new Item { Type = ItemType.Armor, Name = "Chainmail", Cost = 31, Damage = 0, Armor = 2 },
            new Item { Type = ItemType.Armor, Name = "Splintmail", Cost = 53, Damage = 0, Armor = 3 },
            new Item { Type = ItemType.Armor, Name = "Bandedmail", Cost = 75, Damage = 0, Armor = 4 },
            new Item { Type = ItemType.Armor, Name = "Platemail", Cost = 102, Damage = 0, Armor = 5 },
            new Item { Type = ItemType.Ring, Name = "Damage +1", Cost = 25, Damage = 1, Armor = 0 },
            new Item { Type = ItemType.Ring, Name = "Damage +2", Cost = 50, Damage = 2, Armor = 0 },
            new Item { Type = ItemType.Ring, Name = "Damage +3", Cost = 100, Damage = 3, Armor = 0 },
            new Item { Type = ItemType.Ring, Name = "Defense +1", Cost = 20, Damage = 0, Armor = 1 },
            new Item { Type = ItemType.Ring, Name = "Defense +2", Cost = 40, Damage = 0, Armor = 2 },
            new Item { Type = ItemType.Ring, Name = "Defense +3", Cost = 80, Damage = 0, Armor = 3 }
        ];

        protected override long Solve(IEnumerable<string> lines)
        {
            var bossStats = GetBossStats(lines);
            var minimumCost = int.MaxValue;

            foreach (var items in EnumerateSetups())
            {
                var boss = bossStats.Clone();
                var player = new Entity
                {
                    Health = PlayerHealth,
                    Damage = items.Sum(i => i.Damage),
                    Armor = items.Sum(i => i.Armor),
                    GearCost = items.Sum(i => i.Cost)
                };

                if (DoesPlayerWin(player, boss))
                {
                    minimumCost = Math.Min(minimumCost, player.GearCost);
                }
            }


            return minimumCost;
        }

        private static bool DoesPlayerWin(Entity player, Entity boss)
        {
            var attacker = player;
            var defender = boss;

            while (attacker.Health > 0 && defender.Health > 0)
            {
                var damageDealt = Math.Max(1, attacker.Damage - defender.Armor);
                defender.Health -= damageDealt;

                // Swap roles
                (defender, attacker) = (attacker, defender);
            }

            return player.Health > 0;
        }

        private static IEnumerable<Item[]> EnumerateSetups()
        {
            var weapons = ShopItems.Where(i => i.Type == ItemType.Weapon).ToArray();
            var armors = ShopItems.Where(i => i.Type == ItemType.Armor).Prepend(null).ToArray();
            var rings = ShopItems.Where(i => i.Type == ItemType.Ring).ToArray();

            foreach (var weapon in weapons)
            {
                foreach (var armor in armors)
                {
                    // Zero rings
                    yield return new Item[] { weapon, armor }.Where(x => x != null).ToArray();

                    // One ring
                    foreach (var ring1 in rings)
                    {
                        yield return new Item[] { weapon, armor, ring1 }.Where(x => x != null).ToArray();
                    }

                    // Two rings
                    for (var i = 0; i < rings.Length; i++)
                    {
                        for (var j = i + 1; j < rings.Length; j++)
                        {
                            yield return new Item[] { weapon, armor, rings[i], rings[j] }.Where(x => x != null).ToArray();
                        }
                    }
                }
            }
        }

        private static Entity GetBossStats(IEnumerable<string> lines)
        {
            /*
            Hit Points: 109
            Damage: 8
            Armor: 2
            */
            var enumerator = lines.GetEnumerator();

            var health = int.Parse(lines.ElementAt(0).Replace("Hit Points: ", ""));
            var damage = int.Parse(lines.ElementAt(1).Replace("Damage: ", ""));
            var armor = int.Parse(lines.ElementAt(2).Replace("Armor: ", ""));

            return new Entity
            {
                Health = health,
                Damage = damage,
                Armor = armor
            };
        }

        public class Entity
        {
            public int Health { get; set; }
            public int Damage { get; set; }
            public int Armor { get; set; }
            public int GearCost { get; set; }

            public Entity Clone() => new()
            {
                Health = Health,
                Damage = Damage,
                Armor = Armor,
                GearCost = GearCost
            };
        }

        public enum ItemType
        {
            Weapon,
            Armor,
            Ring
        }

        [DebuggerDisplay("{Type}: {Name}")]
        public class Item
        {
            public ItemType Type { get; set; }
            public required string Name { get; set; }
            public int Cost { get; set; }
            public int Damage { get; set; }
            public int Armor { get; set; }
        }
    }
}

        

