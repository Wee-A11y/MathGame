namespace MathGame
{
    internal class Menu
    {
        internal static string ShowMenu(string name)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($@"Hello {name}, which type of game would you like to play? 
        
        'a' : Addition Game
        's' : Subtraction Game
        'd' : Division Game
        'm' : Multiplication Game
        'g' : Game History
        'q' : Quit Game")
                ;

            var choice = Console.ReadLine()!.ToLower().Trim();
            return choice;
        }
    }
}
