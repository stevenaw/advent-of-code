namespace AdventOfCode.Y2020.Dec04
{
    public class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var validCount = 0L;

            var passports = PassportParser.ParsePassports(lines);
            foreach (var passport in passports)
            {
                if (ValidatePassport(passport))
                    validCount++;
            }

            return validCount;
        }

        private static bool ValidatePassport(Dictionary<string, string> passport)
        {
            var requiredFields = new string[]
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid",
                //"cid"
            };

            foreach (var field in requiredFields)
            {
                if (!passport.ContainsKey(field))
                    return false;
            }

            return true;
        }
    }
}
