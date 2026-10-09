string userInput;
var date = DateTime.UtcNow;
List<string> gameHistory = new List<string>();

Console.WriteLine("----------------------------------");
Console.WriteLine($"Hello. Today is {date}. Welcome to the Math Game.\n");

// Game loops until user quits
do
{
    ShowOptions();
    userInput = Console.ReadLine();
    GameLogic(userInput);

}while(userInput != "6");

// Method to show the menu options
void ShowOptions()
{
    Console.WriteLine(@$"----------------------------------
    1 - Addition
    2 - Substraction
    3 - Multiplication
    4 - Divison
    5 - Show Game History
    6 - Quit");
}

// GameLogic to handle the user Input
void GameLogic(string userInput)
{
    switch(userInput){
        case "1":
            CreateGame("+");
            break;
        case "2":
            CreateGame("-");
            break;
        case "3":
            CreateGame("*");
            break;
        case "4":
            CreateGame("/");
            break;
        case "5":
            ShowHistory();
            break;
        case "6":
            break;
    }
}

void CreateGame(string operation)
{
    Random rand = new Random();
    int num1;
    int num2;
    int userAnswer;
    int result;
    int userScore = 0;

    DateTime startTime = DateTime.UtcNow;
    for(int i = 1; i <=5; i++)
    {

        num1 = rand.Next(0,101);
        num2 = rand.Next(1,101);

        // Makes sure the divison result is an integer:
        if (operation == "/")
        {
            while(num1 % num2 != 0)
            {
                num1 = rand.Next(0,101);
            }
        }

        // Parse an int from the user input
        Console.WriteLine($"What is {num1} {operation} {num2} = ?");
        while(!int.TryParse(Console.ReadLine(), out userAnswer))
        {
            Console.WriteLine("Enter a valid number");
        }
        // Calculate the result and check if the users answer is the same
        result = CalculateResult(num1, num2, operation);
        if(result == userAnswer)
        {
            Console.WriteLine($"Correct! The answer was {num1} {operation} {num2} = {result}.");
            userScore = userScore + 1;
        }
        else
        {
            Console.WriteLine($"Incorrect! The answer was {result}.");
        }
    }

    // Add the game to the game history list
    TimeSpan elapsed = DateTime.UtcNow - startTime;
    Console.WriteLine($"Game ended. Your score is: {userScore}. Total Time: {elapsed.TotalSeconds} seconds.");
    gameHistory.Add($"Game {DateTime.UtcNow}: Users Score - {userScore}");
}

// Calculate the result of each question
int CalculateResult(int num1, int num2, string operation)
{
    switch (operation)
    {
        case "+":
            return num1 + num2;
        case "-":
            return num1 - num2;
        case "*":
            return num1 * num2;
        case "/":
            return num1 / num2;
    }        DateTime startTime = DateTime.UtcNow;
    return 0;
}

// Method to show the history
void ShowHistory()
{
    foreach (var game in gameHistory)
    {
        Console.WriteLine(game);
    }
}

