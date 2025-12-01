using AdventOfCode2025;

Console.WriteLine("Advent of Code 2025");

var dayOneInput = await File.ReadAllTextAsync("./Input/DayOne.txt");
AdventSolver<SecretEntrance>.Solve(dayOneInput, 1, "Secret Entrance");