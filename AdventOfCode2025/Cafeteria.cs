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
        while (lines[startIndex].Contains('-'))
        {
            var line = lines[startIndex++];
            var parts = line.Split('-');
            var range = new Range(ulong.Parse(parts[0]), ulong.Parse(parts[1]));
            AddRange(ranges, range);
        }
        
        var fresh = 0;
        for(; startIndex < lines.Length; startIndex++)
        {
            var line = lines[startIndex];
            if (line.Contains('-'))
                continue;

            var num = ulong.Parse(line);
            if(ranges.Any(x => x.IsInRange(num))) fresh++;
        }
        RemoveExtraRanges(ranges);
        var totalFresh = 0UL;
        foreach (var range in ranges)
            totalFresh += range.InclusiveCount;
        
        return new AdventSolution(fresh.ToString(), totalFresh.ToString());
    }

    private void AddRange(HashSet<Range> ranges, Range range)
    {
        var first = ranges.FirstOrDefault(x => x.IsInRange(range.Min));
        if (first != default)
        {
            ranges.Remove(first);
            if(!first.IsInRange(range.Max)) 
                first =  new Range(first.Min, range.Max);
        }
        else
            first = range;
        
        var last = ranges.LastOrDefault(x => x.IsInRange(first.Max));
        if (last != default)
        {
            ranges.Remove(last);
            if (!last.IsInRange(first.Min))
                last = new Range(first.Min,  last.Max);
        }
        else
            last = first;
        
        ranges.Add(last);
    }

    private void RemoveExtraRanges(HashSet<Range> ranges)
    {
        var toRemove = new List<Range>();
        foreach (var range in ranges)
        {
            if(ranges.Any(x => x != range && (x.IsInRange(range.Min) || x.IsInRange(range.Max))))
                toRemove.Add(range);
        }

        foreach (var remove in toRemove)
        {
            ranges.Remove(remove);
            AddRange(ranges, remove);
        }
    }
}