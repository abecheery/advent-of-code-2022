// See https://aka.ms/new-console-template for more information

using DayOne.Solution;

Console.WriteLine("Advent of Code 2022");

var dayOnePartOne = new ChallengePartOne("input.txt");
var resultPartOne = dayOnePartOne.Solve();

var dayOnePartTwo = new ChallengePartTwo(dayOnePartOne);
var resultPartTwo = dayOnePartTwo.Solve();

Console.WriteLine($"Result for part one: {resultPartOne}");
Console.WriteLine($"Result for part two: {resultPartTwo}");
