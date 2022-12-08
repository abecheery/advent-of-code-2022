using DayOne.Models;

namespace DayOne.Solution;

public class ChallengePartTwo
{
    private readonly ChallengePartOne _challengePartOne;

    public ChallengePartTwo(ChallengePartOne challengePartOne)
    {
        _challengePartOne = challengePartOne;
    }
    public double Solve()
    {
        if (_challengePartOne.Deers.Any())
        {
            var calorySumForTopThree = GetTopN(3).Sum(x => x.Calories);
            return calorySumForTopThree;
        }

        _challengePartOne.Solve();
        return Solve();
    }

    private List<Deer> GetTopN(int topNr)
    {
        return _challengePartOne.Deers.OrderByDescending(s => s.Calories).Take(topNr).ToList();
    }
}