using System.Runtime.InteropServices.JavaScript;
using AdventOfCode2025.Utils;

namespace AdventOfCode2025;

public class Lobby : IAdventSolution
{
    public AdventSolution Solve(string input)
    {
        var lines = input.SplitLines();
        var total = 0;
        foreach (var line in lines)
        {
            var first = '0';
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
            
            
            total += int.Parse($"{first}{second}");
        }
        
        return new AdventSolution(total.ToString(), null);
    }
}