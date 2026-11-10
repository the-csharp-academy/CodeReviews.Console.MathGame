namespace MathGame.Models;

internal class Game
{
//    private int _score;
//    public int Score
//    { 
//        get { return _score; }
//        set { _score = value; }
//    }
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
}

internal enum GameType
{ 
    Addition,
    Substraction,
    Multiplication,
    Division
}