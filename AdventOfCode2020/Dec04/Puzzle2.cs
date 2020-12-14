using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Dec04
{
    public class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> fileContents)
        {
            var validCount = 0L;

            var passports = PassportParser.ParsePassports(fileContents);
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
            { "byr", input => Int32.TryParse(input, out var val) && val >= 1920 && val <= 2002 },
            { "iyr", input => Int32.TryParse(input, out var val) && val >= 2010 && val <= 2020 },
            { "eyr", input => Int32.TryParse(input, out var val) && val >= 2020 && val <= 2030 },
            {
                "hgt", input => input.Length >= 4 &&
                  (input[^2..] switch
                  {
                      "cm" => Int32.TryParse(input[..^2], out var val) && val >= 150 && val <= 193,
                      "in" => Int32.TryParse(input[..^2], out var val) && val >= 59 && val <= 76,
                      _ => false
                  })
            },
            { "hcl", input => Regex.IsMatch(input, @"^#[a-z0-9]{6}$") },
            { "ecl", input => Regex.IsMatch(input, @"^(amb|blu|brn|gry|grn|hzl|oth)$") },
            { "pid", input => Regex.IsMatch(input, @"^\d{9}$") }
        };
    }
}
