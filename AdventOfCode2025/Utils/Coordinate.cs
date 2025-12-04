using System.Numerics;

namespace AdventOfCode2025.Utils;

public record struct Coordinate(int X, int Y) : IAdditionOperators<Coordinate,Coordinate,Coordinate>, ISubtractionOperators<Coordinate,Coordinate,Coordinate>
{
    public static Coordinate operator +(Coordinate left, Coordinate right)
    {
        return new Coordinate(left.X + right.X, left.Y + right.Y);
    }

    public static Coordinate operator -(Coordinate left, Coordinate right)
    {
        return new Coordinate(left.X - right.X, left.Y - right.Y);
    }
}