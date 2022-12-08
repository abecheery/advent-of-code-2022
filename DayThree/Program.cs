// See https://aka.ms/new-console-template for more information

using DayThree.Solution;

Console.WriteLine("Advent of Code 2022");

var challengePartOne = new ChallengePartOne("input.txt");
var resultPartOne = challengePartOne.Solve();

var challengePartTwo = new ChallengePartTwo("input.txt");
var resultPartTwo = challengePartTwo.Solve();

Console.WriteLine($"Challenge one result: {resultPartOne}");
Console.WriteLine($"Challenge two result: {resultPartTwo}");
