namespace MathGame.Models
{
    internal class Game
    {
        internal static GameType Type { get; set; }
    }

    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
