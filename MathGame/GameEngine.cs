namespace MathGame
{
    public class GameEngine
    {
        private int _gameLength;
        public int Score;
        private readonly string _name;
        public int FirstNumber;
        public int SecondNumber;
        public string? OperationValue;
        public double Result;
        private bool _gameOn;

        public GameEngine(int gameLength, int score, string name, int firstNumber, int secondNumber,string? operationValue, double result)
        {
            _gameLength = gameLength;
            Score = score;
            _name = name;
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            OperationValue = operationValue;
            Result = result;
        }
        public void Start(List<string> gamesHistory)
        {
            _gameLength = 2;
            var choice = Menu.ShowMenu(_name);
            for (var i = 0; i < _gameLength; i++)
            {
                Console.WriteLine("------------------");
                Console.WriteLine();
                var random = new Random();
                FirstNumber = random.Next(1, 99);
                SecondNumber = random.Next(1, 99);
                Algorithm(choice, gamesHistory);
            }
        }

        public void Game(string? operationValue, double result, int firstNumber, int secondNumber)
        {
            Console.WriteLine($"{firstNumber} {operationValue} {secondNumber}");
            var outcome = Console.ReadLine();
            while(double.TryParse(outcome, out _) == false)
            {
                Console.WriteLine("Your answer need to be an number. Try again.");
                outcome = Console.ReadLine();
            }

            outcome = Helpers.ValidateAnswer(outcome);
            var answer = Math.Round(double.Parse(outcome), 2);

            if (Math.Abs(answer - result) < 0.02)
            {
                Score++;
                Console.WriteLine($"The answer was... {result}. You are correct");
            }
            else
            {
                Console.WriteLine($"Sorry, wrong answer. The correct answer was {result}");
            }

            Console.WriteLine();

            Console.WriteLine($"Your score is {Score}");
        }

        public void Algorithm(string choice, List<string> gamesHistory)
        {
            do
            {
                switch (choice)
                {
                    case "a":
                        OperationValue = "+";
                        Result = FirstNumber + SecondNumber;
                        Game(OperationValue, Result, FirstNumber, SecondNumber);
                        Helpers.AddToHistory(Score, choice, _gameLength, gamesHistory);
                        Helpers.Results(Score, _gameLength);
                        break;
                    case "s":
                        OperationValue = "-";
                        Result = FirstNumber - SecondNumber;
                        Game(OperationValue, Result, FirstNumber, SecondNumber);
                        Helpers.AddToHistory(Score, choice, _gameLength, gamesHistory);
                        Helpers.Results(Score, _gameLength);
                        break;
                    case "d":
                        OperationValue = "/";
                        Result = (double)FirstNumber / SecondNumber;
                        Result = Math.Round(Result, 2);
                        Game(OperationValue, Result, FirstNumber, SecondNumber);
                        Helpers.AddToHistory(Score, choice, _gameLength, gamesHistory);
                        Helpers.Results(Score, _gameLength);
                        break;
                    case "m":
                        OperationValue = "*";
                        Result = FirstNumber * SecondNumber;
                        Game(OperationValue, Result, FirstNumber, SecondNumber);
                        Helpers.AddToHistory(Score, choice, _gameLength, gamesHistory);
                        Helpers.Results(Score, _gameLength);
                        break;
                    case "g":
                        Helpers.GetGameHistory(gamesHistory);
                        _gameLength = 0;
                        _gameOn = false;
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (_gameOn);
        }
    }
}