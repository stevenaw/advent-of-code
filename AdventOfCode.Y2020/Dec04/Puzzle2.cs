using System.Text.RegularExpressions;

namespace AdventOfCode.Y2020.Dec04
{
    public class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var validCount = 0L;

            var passports = PassportParser.ParsePassports(lines);
            foreach (var passport in passports)
                if (ValidatePassport(passport))
                    validCount++;

            return validCount;
        }

        private static bool ValidatePassport(Dictionary<string, string> passport)
        {
            foreach (var validator in Validators)
                if (!passport.TryGetValue(validator.Key, out var passportFieldValue) || !validator.Value(passportFieldValue))
                    return false;

            return true;
        }

        private static readonly Dictionary<string, Predicate<string>> Validators = new()
        {
            { "byr", input => int.TryParse(input, out var val) && val >= 1920 && val <= 2002 },
            { "iyr", input => int.TryParse(input, out var val) && val >= 2010 && val <= 2020 },
            { "eyr", input => int.TryParse(input, out var val) && val >= 2020 && val <= 2030 },
            {
                "hgt",
                input => input.Length >= 4 &&
           input[^2..] switch
           {
               "cm" => int.TryParse(input[..^2], out var val) && val >= 150 && val <= 193,
               "in" => int.TryParse(input[..^2], out var val) && val >= 59 && val <= 76,
               _ => false
           }
            },
            { "hcl", input => Regex.IsMatch(input, @"^#[a-z0-9]{6}$") },
            { "ecl", input => Regex.IsMatch(input, @"^(amb|blu|brn|gry|grn|hzl|oth)$") },
            { "pid", input => Regex.IsMatch(input, @"^\d{9}$") }
        };
    }
}
