// See https://aka.ms/new-console-template for more information

using DayTwo.Solution;

Console.WriteLine("Advent of Code 2022");

var dayTwoPartOne = new ChallengePartOne("input.txt");
var resultOfPartOne = dayTwoPartOne.Solve();

var dayTwoPartTwo = new ChallengePartTwo("input.txt");
var resultOfPartTwo = dayTwoPartTwo.Solve();
Console.WriteLine($"Part one result: {resultOfPartOne}");
Console.WriteLine($"Part two result: {resultOfPartTwo}");

