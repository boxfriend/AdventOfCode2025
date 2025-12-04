using System.Runtime.InteropServices.JavaScript;
using AdventOfCode2025.Utils;

namespace AdventOfCode2025;

public class Lobby : IAdventSolution
{
    public AdventSolution Solve(string input)
    {
        var lines = input.SplitLines();
        var total = 0UL;
        var total2 = 0UL;
        foreach (var line in lines)
        {
            total += GreatestXDigits(line, 2);
            total2 += GreatestXDigits(line, 12);
            /*var first = '0';
            var second = '0';
            for (var i = 0; i < line.Length; i++)
            {
                if (i != line.Length - 1 && line[i] > first)
                {
                    first = line[i];
                    second = line[i + 1];
                }
                else if (line[i] > second)
                {
                    second = line[i];
                }
            }
            total += int.Parse($"{first}{second}");*/
        }
        
        return new AdventSolution(total.ToString(), total2.ToString());
    }

    private readonly List<char> _chars = new();

    private ulong GreatestXDigits(string input, int digits)
    {
        _chars.Clear();
        _chars.Add(input[0]);
        for (var i = 1; i < input.Length; i++)
        {
            var remainingChars = input.Length - i - 1;
            var c = input[i];
            if(!IsReplace(c, remainingChars, digits) && _chars.Count < digits)
            {
                _chars.Add(c);
            }
        }
        
        return ulong.Parse(string.Join("", _chars));
    }

    private bool IsReplace(char c, int remaining, int digits)
    {
        for (var i = 0; i < _chars.Count; i++)
        {
            if (c <= _chars[i] || (remaining < digits - (i+1))) continue;
            _chars.RemoveRange(i, _chars.Count - i);
            _chars.Add(c);
            return true;
        }

        return false;
    }
}