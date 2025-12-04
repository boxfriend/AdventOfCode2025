using AdventOfCode2025;

Console.WriteLine("Advent of Code 2025");

var dayOneInput = await File.ReadAllTextAsync("./Input/DayOne.txt");
AdventSolver<SecretEntrance>.Solve(dayOneInput, 1, "Secret Entrance");

var dayTwoInput = await File.ReadAllTextAsync("./Input/DayTwo.txt");
AdventSolver<GiftShop>.Solve(dayTwoInput, 2, "Gift Shop");

var dayThreeInput = await File.ReadAllTextAsync("./Input/DayThree.txt");
AdventSolver<Lobby>.Solve(dayThreeInput, 3, "Lobby");

var dayFourInput = await File.ReadAllTextAsync("./Input/Test.txt");
AdventSolver<PrintingDepartment>.Solve(dayFourInput, 4, "Printing Department");