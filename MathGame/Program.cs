bool keepPlaying;
Console.WriteLine("What is your name?");
var name = Console.ReadLine(); 
var score = 0;

do
{
    Start();

    string Menu()
    {
        Console.WriteLine();
        Console.WriteLine($@"Hello {name}, which type of game would you like to play? 

        'a' : Addition Game
        's' : Subtraction Game
        'd' : Division Game
        'm' : Multiplication Game
        'q' : Quit Game");

        var choice = Console.ReadLine()!.ToLower().Trim();
        return choice;
    }
    
    void Start()
    {
        var choice = Menu();
        for (var i = 0; i < 2; i++)
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);
            Algorithm(firstNumber, secondNumber, choice);
        }
        PlayAgain();
    }

    void Algorithm(int firstNumber, int secondNumber, string choice)
    {
        string operationValue;
        double result;
        
        switch (choice)
        {
            case "a":
                operationValue = "+";
                result = firstNumber + secondNumber;
                Game(operationValue, result, firstNumber, secondNumber);
                break;
            case "s":
                operationValue = "-";
                result = firstNumber - secondNumber;
                Game(operationValue, result, firstNumber, secondNumber);
                break;
            case "d":
                operationValue = "/";
                result = (double)firstNumber / secondNumber;
                result = Math.Round(result, 2);
                Game(operationValue, result, firstNumber, secondNumber);
                break;
            case "m":
                operationValue = "*";
                result = firstNumber * secondNumber;
                Game(operationValue, result, firstNumber, secondNumber);
                break;
            case "q":
                Console.WriteLine("Goodbye");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid Input");
                break;
        }
    }

    void Game(string operationValue, double result, int firstNumber, int secondNumber)
    {

        Console.WriteLine($"{firstNumber} {operationValue} {secondNumber}");
        var answer = Math.Round(double.Parse(Console.ReadLine()!), 2);

        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (answer == result)
        {
            score++;
            Console.WriteLine($"The answer was... {result}. You are correct");
        }
        else
        {
            Console.WriteLine($"Sorry, wrong answer. The correct answer was {result}");
        }

        Console.WriteLine();
        Console.WriteLine($"Your score is {score}");
        
    }

    void PlayAgain()
    {
        Console.WriteLine();
        Console.WriteLine("Do you want to play another game? 'y' or 'n'");
        var replay = Console.ReadLine();
        KeepPlaying(replay!);
    }

    bool KeepPlaying(string replay)
    {
        if (replay == "y")
        {
            return keepPlaying = true;
        }

        return keepPlaying = false;

    }

} while (keepPlaying);


Environment.Exit(0);




    