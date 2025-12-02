using System.Text.RegularExpressions;

namespace AdventOfCode2025;

public class GiftShop : IAdventSolution
{
    private readonly Regex _regex = new(@"^(.+)\1+$");
    
    public AdventSolution Solve(string input)
    {
        var ranges = input.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        ulong totalInvalid = 0;
        ulong newInvalid = 0;
        foreach (var rangeString in ranges)
        {
            var range = GetRange(rangeString);
            for (var i = range.Min; i <= range.Max; i++)
            {
                if (IsInvalid(i))
                    totalInvalid += i;

                if(IsRepeat(i))
                    newInvalid += i;
            }
        }
        
        return new AdventSolution(totalInvalid.ToString(),newInvalid.ToString());
    }

    private bool IsInvalid(ulong id)
    {
        var s = id.ToString();
        var half = s.Length / 2;
        var first = s[..half];
        var second = s[half..];
        return first == second;
    }
    
    private bool IsRepeat(ulong id) => _regex.IsMatch(id.ToString());

    private Range GetRange(string input)
    {
        var numbers = input.Split('-', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return new Range(ulong.Parse(numbers[0]), ulong.Parse(numbers[^1]));
    }
}

public record struct Range(ulong Min, ulong Max);