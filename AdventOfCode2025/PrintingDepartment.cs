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
        var initialCount = _existingRolls.Count;
        var accessible = -1;
        var firstAccessible = -1;
        var toRemove = new HashSet<Coordinate>();
        while(accessible != 0 && _existingRolls.Count > 0)
        {
            accessible = 0;
            foreach (var c in _existingRolls)
            {
                if (!IsAccessible(c)) continue;
                accessible++;
                toRemove.Add(c);
            }
            
            if (firstAccessible == -1) firstAccessible = accessible;
            
            _existingRolls.RemoveWhere(x => toRemove.Contains(x));
            toRemove.Clear();
        } 

        return new AdventSolution(firstAccessible.ToString(), (initialCount - _existingRolls.Count).ToString());
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