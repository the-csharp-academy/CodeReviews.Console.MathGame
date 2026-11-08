using System.ComponentModel.Design;
using System.Formats.Asn1;

Console.WriteLine("Please type your name");
string? name = Console.ReadLine();

var games = new List<string>();
Random rand = new Random();
int answer;
bool playAgain = true;


WhichGame();


// Main method to call games
void WhichGame()
{
    do
    {
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"Hello {name.ToUpper()} today's date is {DateTime.UtcNow}. Here is the menu for today's game:");
        Console.WriteLine($@"Please select a game you would like to play.
        V - View Previous Games
        A - Addition
        S - Subtraction
        M - Multiplication
        D - Division
        Q - Quit the program");
        Console.WriteLine("------------------------------------------");
        var gameSelected = Console.ReadLine().Trim().ToUpper();
        Console.Clear();

        switch (gameSelected)
        {
            case "V":
            GetGames();
            break;
            case "A":
            Console.Clear();
            Console.WriteLine("Addition Game Selected");
            AdditionGame();
            break;

            case "S":
            Console.Clear();
            Console.WriteLine("Subtraction Game Selected");
            SubtractionGame();
            break;

            case "M":
            Console.Clear();
            Console.WriteLine("Multiplication Game Selected");
            MultiGame();
            break;

            case "D":
            Console.Clear();
            Console.WriteLine("Division Game Selected");
            DivisionGame();
            break;

            case "Q":
            playAgain = false;
            Console.WriteLine("User has quit the game");
            break;

            default:

            Console.WriteLine("Invalid Input");
            break;
        }
    } while (playAgain);


}

void GetGames()
{
    Console.Clear();
    Console.WriteLine("Game History");
    Console.WriteLine("-------------------");
    foreach (var game in games)
    {
        Console.WriteLine(game);
    }
    Console.WriteLine("-------------------\n");
    Console.WriteLine("Press any key to return to the menu");
    Console.ReadLine();
}

// Methods for each game
void AdditionGame()
{
    int questions = 0;
    int points = 0;

    do
    {
        int num1 = rand.Next(10);
        int num2 = rand.Next(10);
        answer = (num1 + num2);

        Console.WriteLine($"Solve {num1} + {num2}");
        int userAn = Convert.ToInt32(Console.ReadLine());
        questions++;

        if (answer == userAn) // Point tracker
        {
            points++;
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }

    } while (questions < 7); // Loop questions until 7

    Console.WriteLine("You finished with a score of " + points + "!");
    Console.WriteLine("Press any key to play again");

    AddToHistory(points, "Addition");
}

void SubtractionGame()
{
    int questions = 0;
    int points = 0;

    do
    {
        int num1 = rand.Next(10);
        int num2 = rand.Next(10);
        answer = (num1 - num2);

        Console.WriteLine($"Solve {num1} - {num2}");
        int userAn = Convert.ToInt32(Console.ReadLine());
        questions++;

        if (answer == userAn) // Point tracker
        {
            points++;
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }

    } while (questions < 7); // Loop questions until 7

    Console.WriteLine("You finished with a score of " + points + "!");
    Console.WriteLine("Press any key to play again");

    AddToHistory(points, "Subtraction");
}

void MultiGame()
{
    int questions = 0;
    int points = 0;

    do
    {
        int num1 = rand.Next(10);
        int num2 = rand.Next(10);
        answer = (num1 * num2);

        Console.WriteLine($"Solve {num1} * {num2}");
        int userAn = Convert.ToInt32(Console.ReadLine());
        questions++;

        if (answer == userAn) // Point tracker
        {
            points++;
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }

    } while (questions < 7); // Loop questions until 7

    Console.WriteLine("You finished with a score of " + points + "!");
    Console.WriteLine("Press any key to play again");

    AddToHistory(points, "Multiplication");
}

void DivisionGame()
{
    int questions = 0;
    int points = 0;

    do
    {
        int num1 = rand.Next(1, 99);
        int num2 = rand.Next(1, 99);

        while (num1 % num2 != 0) // Chooses other numbers incase result has a decimal
        {
            num1 = rand.Next(1, 99);
            num2 = rand.Next(1, 99);
        }
        answer = (num1 / num2);

        Console.WriteLine($"Solve {num1} / {num2}");
        int userAn = Convert.ToInt32(Console.ReadLine());
        questions++;

        if (answer == userAn) // Point tracker
        {
            points++;
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Incorrect!");
        }

    } while (questions < 7); // Loop questions until 7

    Console.WriteLine("You finished with a score of " + points + "!");
    Console.WriteLine("Press any key to play again");

    AddToHistory(points, "Division");
}

// Method to keep track of game history
void AddToHistory(int gameScore, string gameType)
{
    games.Add($"{DateTime.Now} - {gameType}: {gameScore} points");
}
