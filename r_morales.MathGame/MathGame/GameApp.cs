GameState currentGameState = GameState.MainMenu;
List<GameData> playedGames = new List<GameData>();

ChangeGameState(GameState.MainMenu);

void ChangeGameState(GameState newGameState)
{
    Console.Clear();
    currentGameState = newGameState;

    switch (currentGameState)
    {
        case GameState.MainMenu:
            ShowMainMenu();
            break;
        case GameState.Addition:
            Console.WriteLine("\nYou have chosen the addition game!");
            ConfigureGame(currentGameState);
            break;
        case GameState.Subtraction:
            Console.WriteLine("\nYou have chosen the subtraction game!");
            ConfigureGame(currentGameState);
            break;
        case GameState.Multiplication:
            Console.WriteLine("\nYou have chosen the multiplication game!");
            ConfigureGame(currentGameState);
            break;
        case GameState.Division:
            Console.WriteLine("\nYou have chosen the division game!");
            ConfigureGame(currentGameState);
            break;
    }
}

void ShowMainMenu()
{
    HandleMainMenuInput();
}
void HandleMainMenuInput()
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game!");
    Console.WriteLine("\nEnter your choice: \n1 - Addition Game | 2 - Subtraction Game | 3 - Multiplication Game | 4 - Division Game | 5 - History | 6 - Exit");
    ConsoleKeyInfo userInput = Console.ReadKey();
    switch (userInput.Key)
    {
        case ConsoleKey.D1:
            ChangeGameState(GameState.Addition);
            break;
        case ConsoleKey.NumPad1:
            ChangeGameState(GameState.Addition);
            break;
        case ConsoleKey.D2:
            ChangeGameState(GameState.Subtraction);
            break;
        case ConsoleKey.NumPad2:
            ChangeGameState(GameState.Subtraction);
            break;
        case ConsoleKey.D3:
            ChangeGameState(GameState.Multiplication);
            break;
        case ConsoleKey.NumPad3:
            ChangeGameState(GameState.Multiplication);
            break;
        case ConsoleKey.D4:
            ChangeGameState(GameState.Division);
            break;
        case ConsoleKey.NumPad4:
            ChangeGameState(GameState.Division);
            break;
        case ConsoleKey.D5:
            CheckGamesHistory();
            break;
        case ConsoleKey.NumPad5:
            CheckGamesHistory();
            break;
        case ConsoleKey.D6:
            ExitApplication();
            break;
        case ConsoleKey.NumPad6:
            ExitApplication();
            break;
        default:
            Console.WriteLine("\nInvalid input. Please try again.");
            HandleMainMenuInput();
            break;
    }
}

void ConfigureGame(GameState gameType)
{
    Console.WriteLine("\nHow many rounds would you like to play?");

    int inputNumber = 0;
    while (!int.TryParse(Console.ReadLine(), out inputNumber) || inputNumber <= 0)
    {
        Console.WriteLine("Please input a valid number");
    }

    GameData gameData = new GameData(inputNumber, gameType);
    HandleCurrentGame(gameData);
}

void HandleCurrentGame(GameData gameData)
{
    Console.Clear();
    int currentRoundNumber = 1;
    while (currentRoundNumber <= gameData.GetNumberOfRoundsToPlay())
    {
        int result = 0;

        switch (currentGameState)
        {
            case GameState.Addition:
                result = SelectAdditionNumbers();
                break;
            case GameState.Subtraction:
                result = SelectSubtractionNumbers();
                break;
            case GameState.Multiplication:
                result = SelectMultiplicationNumbers();
                break;
            case GameState.Division:
                result = SelectDivisionNumbers();
                break;
        }

        int inputNumber;
        while (!int.TryParse(Console.ReadLine(), out inputNumber))
        {
            Console.WriteLine("Please input a valid number");
        }

        if (inputNumber == result)
        {
            Console.WriteLine("\nYou guessed correctly!");
            gameData.IncreasePlayerScore();
        }
        else
        {
            Console.WriteLine($"\nSorry, you guessed incorrectly. The correct answer was: {result}");
        }

        currentRoundNumber++;
    }

    playedGames.Add(gameData);
    Console.WriteLine($"\nYour final score was {gameData.GetPlayerScore()}");
    Console.WriteLine("\nPress any key to continue");
    Console.ReadKey();
    ChangeGameState(GameState.MainMenu);
}

int SelectAdditionNumbers()
{
    Random rnd = new Random();
    int numberA = rnd.Next(1, 100);
    int numberB = rnd.Next(1, 100);

    Console.WriteLine($"\nInput the result of {numberA} + {numberB}");

    return numberA + numberB;
}

int SelectSubtractionNumbers()
{
    Random rnd = new Random();
    int numberA = rnd.Next(1, 100);
    int numberB = rnd.Next(1, 100);

    while (numberA - numberB < 0)
    {
        numberA = rnd.Next(1, 100);
        numberB = rnd.Next(1, 100);
    }

    Console.WriteLine($"\nInput the result of {numberA} - {numberB}");
    return numberA - numberB;
}

int SelectMultiplicationNumbers()
{
    Random rnd = new Random();
    int numberA = rnd.Next(1, 100);
    int numberB = rnd.Next(1, 100);

    Console.WriteLine($"\nInput the result of {numberA} multiplied by {numberB}");

    return numberA * numberB;
}

int SelectDivisionNumbers()
{
    Random rnd = new Random();
    int numberA = rnd.Next(0, 100);
    int numberB = rnd.Next(1, 100);

    while (numberA % numberB > 0)
    {
        numberA = rnd.Next(1, 100);
        numberB = rnd.Next(1, 100);
    }

    Console.WriteLine($"\nInput the result of {numberA} divided by {numberB}");

    return numberA / numberB;
}

void CheckGamesHistory()
{
    Console.Clear();
    if (playedGames.Count > 0)
    {
        Console.WriteLine("\nShowing game history.\n");
        int gameNumber = 1;
        foreach(GameData game in playedGames)
        {
            Console.WriteLine($"Game #{gameNumber} - {game.GetGameType()} - Score: {game.GetPlayerScore()} - Rounds: {game.GetNumberOfRoundsToPlay()}");
            gameNumber++;
        }
    }
    else
    {
        Console.WriteLine("\nThere are no games played recently");
    }

    Console.WriteLine("\nPress any key to continue");
    Console.ReadKey();
    ChangeGameState(GameState.MainMenu);
}

void ExitApplication()
{
    Console.WriteLine("\nExiting the game. Goodbye!");
    Environment.Exit(0);
}

public enum GameState
{
    MainMenu,
    Addition,
    Subtraction,
    Multiplication,
    Division
}