namespace MathGame;

internal class Program
{
    public static int FirstNumber;
    public static int SecondNumber;
    public static string? OperationValue;
    public static double Result;

    public Program( int firstNumber, int secondNumber, string? operationValue, double result)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
        OperationValue = operationValue;
        Result = result;
    }
    public static void Main()
    {
        var gamesHistory = new List<string>();

        const int score = 0;
        const int gameLength = 2;
        var name = Helpers.GetName();

        do
        {
            if (name == null) continue;
            GameEngine engine = new(gameLength, score, name, FirstNumber, SecondNumber, OperationValue, Result);

            engine.Start(gamesHistory);
        } while (Helpers.KeepPlaying());
    }
}