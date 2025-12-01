namespace AdventOfCode2025;

public interface IAdventSolution
{
    public AdventSolution Solve(string input);
}

public record struct AdventSolution(string PartOne, string PartTwo);

public class AdventSolver<T> where T : IAdventSolution, new()
{
    public static void Solve(string input, int day, string title)
    {
        var solver = new T();
        var solution = solver.Solve(input);
        Console.WriteLine($"Day {day}: {title}\nPart 1: {solution.PartOne}\nPart 2: {solution.PartTwo}");
    }
}