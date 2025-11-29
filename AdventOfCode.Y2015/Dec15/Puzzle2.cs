using System.Text.RegularExpressions;

namespace AdventOfCode.Y2015.Dec15
{
    internal partial class Puzzle2 : AdventPuzzle
    {
        const int recipeSize = 100;

        protected override long Solve(IEnumerable<string> lines)
        {
            Ingredient[] ingredients = new Ingredient[4];
            var ingredientCount = 0;

            foreach (var line in lines)
            {
                var parts = ParseLine().Match(line).Groups;

                ingredients[ingredientCount++] = new Ingredient
                {
                    Name = parts[1].Value,
                    Capacity = int.Parse(parts[2].Value),
                    Durability = int.Parse(parts[3].Value),
                    Flavor = int.Parse(parts[4].Value),
                    Texture = int.Parse(parts[5].Value),
                    Calories = int.Parse(parts[6].Value),
                };
            }

            var maxScore = EnumerateRecipes(ingredients).Max();

            return maxScore;

            static IEnumerable<long> EnumerateRecipes(Ingredient[] ingredients)
            {
                for (int i = 0; i <= recipeSize; i++)
                {
                    for (int j = 0; j <= recipeSize - i; j++)
                    {
                        for (int k = 0; k <= recipeSize - i - j; k++)
                        {
                            var l = recipeSize - i - j - k;
                            var calories = ingredients[0].Calories * i +
                                           ingredients[1].Calories * j +
                                           ingredients[2].Calories * k +
                                           ingredients[3].Calories * l;

                            if (calories != 500)
                            {
                                continue;
                            }

                            var capacity = ingredients[0].Capacity * i +
                                           ingredients[1].Capacity * j +
                                           ingredients[2].Capacity * k +
                                           ingredients[3].Capacity * l;
                            var durability = ingredients[0].Durability * i +
                                             ingredients[1].Durability * j +
                                             ingredients[2].Durability * k +
                                             ingredients[3].Durability * l;
                            var flavor = ingredients[0].Flavor * i +
                                         ingredients[1].Flavor * j +
                                         ingredients[2].Flavor * k +
                                         ingredients[3].Flavor * l;
                            var texture = ingredients[0].Texture * i +
                                          ingredients[1].Texture * j +
                                          ingredients[2].Texture * k +
                                          ingredients[3].Texture * l;

                            capacity = Math.Max(0, capacity);
                            durability = Math.Max(0, durability);
                            flavor = Math.Max(0, flavor);
                            texture = Math.Max(0, texture);
                            var score = capacity * durability * flavor * texture;

                            if (score > 0)
                            {
                                yield return score;
                            }
                        }
                    }
                }
            }
        }

        [GeneratedRegex(@"^(\w+): capacity (-?\d+), durability (-?\d+), flavor (-?\d+), texture (-?\d+), calories (-?\d+)$")]
        private static partial Regex ParseLine();
        public class Ingredient
        {
            public string Name { get; set; }
            public int Capacity { get; set; }
            public int Durability { get; set; }
            public int Flavor { get; set; }
            public int Texture { get; set; }
            public int Calories { get; set; }
        }
    }
}
