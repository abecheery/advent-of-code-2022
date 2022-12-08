using System.Reflection;

namespace DayThree.Solution;

public class ChallengePartTwo
{
    private readonly string _inputPath;

    public ChallengePartTwo(string input)
    {
        _inputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Input", input);;
    }

    public int Solve()
    {
        var lines = File.ReadAllLines(_inputPath).ToList();
        var totalSum = 0;
        for (var i = 0; i < lines.Count; i+=3)
        {
            var firstLine = lines[i];

            var secondLine = lines[i + 1];
            var similarChar = firstLine.ToCharArray().First(c => secondLine.Contains(c));
            totalSum += CalculatePoints(similarChar);
        }

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