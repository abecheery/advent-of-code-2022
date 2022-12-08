using System.Reflection;

namespace DayThree.Solution;

public class ChallengePartOne
{
    private readonly string _inputPath;

    public ChallengePartOne(string input)
    {
        _inputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Input", input);;
    }

    public int Solve()
    {
        var totalSum = 0;
        var lines = File.ReadAllLines(_inputPath).ToList();
        lines.ForEach(line =>
        {
            var firstCompartment = line[..(line.Length / 2)];
            var secondCompartment = line.Substring(line.Length / 2, line.Length / 2);
            //totalSum += firstCompartment.ToCharArray().Where(c => secondCompartment.Contains(c)).Sum(CalculatePoints);
            totalSum += CalculatePoints(firstCompartment.ToCharArray().First(c => secondCompartment.Contains(c)));
        });

        return totalSum;
    }

    private int CalculatePoints(char c)
    {
        if (char.IsLower(c))
        {
            return c - 96;
        }

        return c - 38;
    }
}