namespace DayTwo.Models;

public class Shape
{
    public string Name { get; set; }
    public int Points { get; set; }
    public List<char> Symbols { get; set; }

    public Shape(string name, int points, List<char> symbols)
    {
        Name = name;
        Points = points;
        Symbols = symbols;
    }
}