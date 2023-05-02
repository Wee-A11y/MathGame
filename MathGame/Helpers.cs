using System.Reflection.Metadata.Ecma335;
using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {

        internal static string GetName()
        {
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }
            return name;
        }
        internal static void AddToHistory(int score, string choice, int gameLength, List<string> gamesHistory)
        {
            Game.Type = choice switch
            {
                "a" => GameType.Addition,
                "s" => GameType.Subtraction,
                "d" => GameType.Division,
                "m" => GameType.Multiplication,
                _ => GameType.Addition
            };

            gamesHistory.Add($"{DateTime.Now} - {Game.Type} : {score} out of {gameLength} games");
        }

        internal static void GetGameHistory(List<string> gamesHistory)
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("----------------------\n");
            foreach (var game in gamesHistory)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------\n");
        }

        internal static void Results(int score, int gameLength)
        {
            Console.WriteLine();
            Console.WriteLine($"You you won {score} out of {gameLength} games");
        }

        internal static bool KeepPlaying()
        {
            bool keepPlaying;
            Console.WriteLine();
            
            Console.WriteLine("Do you want to play another game? 'y' or 'n'");
            var replay = Console.ReadLine();
            if (replay == "y")
            {
                keepPlaying = true;
                return keepPlaying;
            }
            keepPlaying = false;
            return keepPlaying;
        }

        public static string ValidateAnswer(string outcome)
        {
            while (double.TryParse(outcome, out _) == false)
            {
                Console.WriteLine("Your answer need to be an number. Try again.");
                outcome = Console.ReadLine();
            }
            return outcome;
        }
    }
}
