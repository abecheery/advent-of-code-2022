using System.Reflection;
using DayTwo.Models;

namespace DayTwo.Solution;

public class ChallengePartTwo
{
        private readonly string _inputPath;
    
        public List<Shape> Shapes { get; set; }
    
        private readonly Dictionary<Shape, Shape> _combinations = new ();
        private readonly Dictionary<string, int> _scores = new();
        private readonly Dictionary<char, string> _resultSymbols = new ();

        private Shape this[char symbol] => Shapes.FirstOrDefault(shape => shape.Symbols.Contains(symbol))!;
    
        public ChallengePartTwo(string input)
        {
            _inputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Input", input);
            
            PopulateScores();
            PopulateShapesAndCombinations();
            PopulateResultSymbols();
        }
    
        public int Solve()
        {
            var myTotalPoints = 0;
            var lines = File.ReadAllLines(_inputPath).ToList();
            lines.ForEach(line =>
            {
                var roundResult = line.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray();
                var elfsShape = this[roundResult[0]];
                var resultSymbol = roundResult[1];

                var shapeToPlay = CalculateWhatToPlay(elfsShape, _resultSymbols[resultSymbol]);
                myTotalPoints += shapeToPlay.Points;
                // Calculate the winning points as well
                myTotalPoints += CalculatePlayersPoints(shapeToPlay, elfsShape);
            });
    
            return myTotalPoints;
        }
    
        public int CalculatePlayersPoints(Shape playersShape, Shape elfsShape)
        {
            var beatbleShapesByPlayer = _combinations[playersShape];
            if (playersShape == elfsShape)
            {
                return _scores[Constants.Constants.Draw];
            }
    
            if (beatbleShapesByPlayer == elfsShape)
            {
                return _scores[Constants.Constants.Win];
            }
    
            return _scores[Constants.Constants.Lose];
        }
    
        private void PopulateScores()
        {
            _scores.Add(Constants.Constants.Win, 6);
            _scores.Add(Constants.Constants.Lose, 0);
            _scores.Add(Constants.Constants.Draw, 3);
        }
    
        private void PopulateShapesAndCombinations()
        {
            var rock = new Shape(Constants.Constants.Rock, 1, new List<char> { 'A', 'X' });
            var paper = new Shape(Constants.Constants.Paper, 2, new List<char> { 'B', 'Y' });
            var scissors = new Shape(Constants.Constants.Scissors, 3, new List<char> { 'C', 'Z' });
            Shapes = new List<Shape>
            {
                rock,
                paper,
                scissors
            };
    
            _combinations.Add(rock, scissors);
            _combinations.Add(scissors, paper);
            _combinations.Add(paper, rock);
        }

        private Shape CalculateWhatToPlay(Shape opponentsShape, string endGameResult)
        {
            return endGameResult switch
            {
                Constants.Constants.Draw => opponentsShape,
                Constants.Constants.Win => _combinations.FirstOrDefault(x => x.Value.Name == opponentsShape.Name).Key,
                _ => _combinations[opponentsShape]
            };
        }

        private void PopulateResultSymbols()
        {
            _resultSymbols.Add('Z', Constants.Constants.Win);
            _resultSymbols.Add('Y', Constants.Constants.Draw);
            _resultSymbols.Add('X', Constants.Constants.Lose);
        }
}