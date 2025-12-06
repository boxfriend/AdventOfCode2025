using AdventOfCode2025.Utils;

namespace AdventOfCode2025;

public class TrashCompactor : IAdventSolution
{
    public AdventSolution Solve(string input)
    {
        var lines = input.SplitLines();
        var operators = lines[^1].Split(' ',  StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var results = new ulong[operators.Length];
        for (var i = 0; i < lines.Length - 1; i++)
        {
            var line = lines[i].Split(' ',  StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            for (var j = 0; j < line.Length; j++)
            {
                if(i == 0)
                    results[j] = ulong.Parse(line[j]);
                else switch (operators[j])
                {
                    case "+":
                        results[j] += ulong.Parse(line[j]);
                        break;
                    case "*":
                        results[j] *= ulong.Parse(line[j]);
                        break;
                }
            }
        }
        var sum = results.Aggregate(0UL, (current, result) => current + result);

        return new AdventSolution(sum.ToString(),null);
    }
}