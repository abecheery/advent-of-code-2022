// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");

var challengeOne = new ChallengeOne.ChallengeOne("challenge-one-input.txt");
var result = challengeOne.SolvePartOne();
var partTwoResult = challengeOne.SolvePartTwo();

Console.WriteLine($"The maximum number of calories carried by a deer is {result}");
Console.WriteLine($"Top three calories: {partTwoResult}");