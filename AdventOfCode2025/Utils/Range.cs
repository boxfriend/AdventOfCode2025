namespace AdventOfCode2025.Utils;

public record struct Range(ulong Min, ulong Max)
{
    public ulong InclusiveCount => Max - Min + 1;
    
    public bool IsInRange(ulong value) => value >= Min && value <= Max;
}