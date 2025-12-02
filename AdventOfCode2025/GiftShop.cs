using System.Text.RegularExpressions;

namespace AdventOfCode2025;

public class GiftShop : IAdventSolution
{
    public AdventSolution Solve(string input)
    {
        var ranges = input.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        ulong totalInvalid = 0;
        foreach (var rangeString in ranges)
        {
            var range = GetRange(rangeString);
            for (var i = range.Min; i <= range.Max; i++)
            {
                if(IsInvalid(i))
                    totalInvalid += (ulong)i;
                    
            }
        }
        
        return new AdventSolution(totalInvalid.ToString(), null);
    }

    private bool IsInvalid(ulong id)
    {
        var s = id.ToString();
        var half = s.Length / 2;
        var first = s[..half];
        var second = s[half..];
        return first == second;
    }

    private Range GetRange(string input)
    {
        var numbers = input.Split('-', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return new Range(ulong.Parse(numbers[0]), ulong.Parse(numbers[^1]));
    }
}

public record struct Range(ulong Min, ulong Max);