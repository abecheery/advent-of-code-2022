using System.Reflection;
using DayOne.Models;

namespace DayOne.Solution;

public class ChallengePartOne
{
    private readonly string _inputPath;
    public List<Deer> Deers { get; set; } = new ();
    
    public ChallengePartOne(string input)
    {
        _inputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Input", input);
    }

    public double Solve()
    {
        var lines = File.ReadAllLines(_inputPath).ToList();
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

        Solve();
        return SolvePartTwo();
    }

    private List<Deer> GetTopN(int topNr)
    {
        return Deers.OrderByDescending(s => s.Calories).Take(topNr).ToList();
    }
}