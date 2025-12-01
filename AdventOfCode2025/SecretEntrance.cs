namespace AdventOfCode2025;

public class SecretEntrance : IAdventSolution
{
    public AdventSolution Solve(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        
        var current = 50;
        var password = 0;
        var password2 = 0;
        foreach (var line in lines)
        {
            var direction = line[0] == 'L' ? -1 : 1;
            var distance =  int.Parse(line.Substring(1));
            var change = distance * direction;
            for (var temp = current; distance > 0; distance--)
            {
                temp += direction;
                temp %= 100;
                if(temp == 0) password2++;
            }

            
            current += change;
            current %= 100;
            if(current == 0) password++;
        }
        
        return new AdventSolution(password.ToString(), password2.ToString());
    }
}