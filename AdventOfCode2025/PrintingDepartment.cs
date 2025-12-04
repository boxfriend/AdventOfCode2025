using AdventOfCode2025.Utils;

namespace AdventOfCode2025;

public class PrintingDepartment : IAdventSolution
{
    private readonly HashSet<Coordinate> _existingRolls = new();
    public AdventSolution Solve(string input)
    {
        var map = input.SplitLines();
        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                if(map[i][j] != '.')
                    _existingRolls.Add(new Coordinate(j, i));
            }
        }

        var accessible = 0;
        foreach (var c in _existingRolls)
        {
            if(IsAccessible(c)) accessible++;
        }
        
        return new AdventSolution(accessible.ToString(), null);
    }

    private readonly Coordinate[] _directions =
    [
        new(-1, -1), new( 0, -1), new( 1, -1),
        new(-1,  0),              new( 1,  0),
        new(-1,  1), new( 0,  1), new( 1,  1)
    ];
    private bool IsAccessible(Coordinate position)
    {
        var neighbors = 0;
        foreach (var dir in _directions)
        {
            if(_existingRolls.Contains(position + dir)) neighbors++;
        }
        return neighbors < 4;
    }
}