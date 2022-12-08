using System.Reflection;
using Shared;

namespace ChallengeOne;

public class ChallengeOne
{
    private readonly string _input;

    public ChallengeOne(string input)
    {
        _input = input;
    }
    private List<Deer> Deers { get; set; } = new ();

    public double SolvePartOne()
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"Input.txt");

        var lines = File.ReadAllLines(path).ToList();
        var index = 0;
        var calorySumPerDeer = 0d;
        lines.ForEach(line =>
        {
            index++;
            if (double.TryParse(line, out var calory))
            {
                calorySumPerDeer += calory;
            }
            else
            {
                Deers.Add(new Deer
                {
                    Name = $"Deer {index}",
                    Calories = calorySumPerDeer
                });
                
                calorySumPerDeer = 0;
            }
        });

        return Deers.Max(deer => deer.Calories);
    }

    public double SolvePartTwo()
    {
        if (Deers.Any())
        {
            var calorySumForTopThree = GetTopN(3).Sum(x => x.Calories);
            return calorySumForTopThree;
        }

        SolvePartOne();
        return SolvePartTwo();
    }

    private List<Deer> GetTopN(int topNr)
    {
        return Deers.OrderByDescending(s => s.Calories).Take(topNr).ToList();
    }
}