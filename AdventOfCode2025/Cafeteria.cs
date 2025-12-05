using AdventOfCode2025.Utils;
using Range = AdventOfCode2025.Utils.Range;

namespace AdventOfCode2025;

public class Cafeteria : IAdventSolution
{
    public AdventSolution Solve(string input)
    {
        var lines = input.SplitLines();

        var ranges = new HashSet<Range>();
        var startIndex = 0;
        while (lines[startIndex].Contains("-"))
        {
            var line = lines[startIndex++];
            var parts = line.Split('-');
            ranges.Add(new(ulong.Parse(parts[0]), ulong.Parse(parts[1])));
        }
        
        var fresh = 0;
        for(; startIndex < lines.Length; startIndex++)
        {
            var line = lines[startIndex++];
            if (line.Contains('-'))
                continue;

            var num = ulong.Parse(line);
            if(ranges.Any(x => x.Min <= num && num <= x.Max)) fresh++;
        }

        
        return new AdventSolution(fresh.ToString(), null);
    }
}