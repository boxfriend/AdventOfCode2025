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
            var max = 0;
            for (var i = 0; i < line.Length; i++)
            {
                for (var j = i + 1; j < line.Length; j++)
                {
                    var num = int.Parse(line[i].ToString() + line[j].ToString());
                    if (num > max) max = num;
                    
                }
            }
            total += max;
        }
        
        return new AdventSolution(total.ToString(), null);
    }
}