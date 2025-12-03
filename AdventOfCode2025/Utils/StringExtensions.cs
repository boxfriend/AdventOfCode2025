namespace AdventOfCode2025.Utils;

public static class StringExtensions
{
    public static string[] SplitLines(this string input)
    {
        return input.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }
}