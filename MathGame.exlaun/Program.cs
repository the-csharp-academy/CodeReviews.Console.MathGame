/*
1-You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), 
collecting the input and adding a point in case of a correct answer.
2-A game needs to have at least 5 questions.
3-The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. 
Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
4-Users should be presented with a menu to choose an operation
5-You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
6-You don't need to record results on a database. Once the program is closed the results will be deleted.
*/

using System.Diagnostics;
using System.Linq.Expressions;
using MathGame_CSharpAcademy;

MathGameLogic mathGame = new MathGameLogic();
Random random = new Random();
int firstNumber, secondNumber, userMenuSelection, score = 0;
bool gameOver = false;

DifficultyLevel difficultyLevel = DifficultyLevel.Easy;

while (!gameOver)
{
    userMenuSelection = GetUserMenuSelection(mathGame);

    firstNumber = random.Next(1,101);
    secondNumber = random.Next(1, 101);
    switch (userMenuSelection)
    {
        case 1:
            score += await PerformOperation(mathGame, firstNumber, secondNumber, score, '+', difficultyLevel);
            break;
        case 2:
            score += await PerformOperation(mathGame, firstNumber, secondNumber, score, '-', difficultyLevel);
            break;
        case 3:
            score += await PerformOperation(mathGame, firstNumber, secondNumber, score, '*', difficultyLevel);
            break;
        case 4:
            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 101);
                secondNumber = random.Next(1, 101);
            }
            score += await PerformOperation(mathGame, firstNumber, secondNumber, score, '/', difficultyLevel);
            break;
        case 5:
            int numberOfQuestions = 99;
            Console.WriteLine("Please enter a number of questions you want to attempt.");
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions))
            {
                Console.WriteLine("Please enter the number of questions you want to attempt as an integer.");
            }
            while (numberOfQuestions > 0)
            {
                int randomOperation = random.Next(1, 5);
                if (randomOperation == 1)
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, score, '+', difficultyLevel);
                }
                else if (randomOperation == 2)
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, score, '-', difficultyLevel);
                }
                else if (randomOperation == 3)
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, score, '*', difficultyLevel);
                }
                else
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(1, 101);
                        secondNumber = random.Next(1, 101);
                    }
                    score += await PerformOperation(mathGame, firstNumber, secondNumber, score, '/', difficultyLevel);
                }
                numberOfQuestions--;
            }
            break;
        case 6:
            Console.WriteLine("GAME HISTORY: \n");
            foreach (var operation in mathGame.GameHistory)
            {
                Console.WriteLine($"{operation}");
            }
            break;
        case 7:
            difficultyLevel = ChangeDifficulty();
            DifficultyLevel difficultyEnum = (DifficultyLevel)difficultyLevel;
            Enum.IsDefined(typeof(DifficultyLevel), difficultyEnum);
            Console.WriteLine($"Your new difficulty level: {difficultyLevel}");
            break;
        case 8:
            gameOver = true;
            Console.WriteLine($"Your final score is: {score}");
            break;
    }
}

static DifficultyLevel ChangeDifficulty()
{
    int userSelection = 0;

    Console.WriteLine("Please enter a difficulty level");
    Console.WriteLine("1. Easy");
    Console.WriteLine("2. Medium");
    Console.WriteLine("3. Hard");

    while (!int.TryParse(Console.ReadLine(), out userSelection) || (userSelection < 1 || userSelection > 3))
    {
        Console.WriteLine("Please enter a valid option 1-3");
    }
    switch (userSelection)
    {
        case 1:
            return DifficultyLevel.Easy;
        case 2:
            return DifficultyLevel.Medium;
        case 3:
            return DifficultyLevel.Hard;
        default:
            return DifficultyLevel.Easy;
    }
}
static void DisplayMathGameQuestion(int firstNumber,int secondNumber,char operaion)
{
    Console.WriteLine($"{firstNumber} {operaion} {secondNumber} = ??");
}
static int GetUserMenuSelection(MathGameLogic mathGame)
{
    int selection = -1;
    mathGame.ShowMenu();
    while (selection < 1 || selection > 8)
    {
        while (!int.TryParse(Console.ReadLine(), out selection))
        {
            Console.WriteLine("Please enter a valid option 1-8");
        }

        if (!(selection >= 1 && selection <= 8))
        {
            Console.WriteLine("Please enter a valid option 1-8");
        }
    }
    return selection;
}

static async Task<int?> GetUserResponse(DifficultyLevel difficulty)
{
    int response = 0;
    int timeout = (int)difficulty;

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    Task<string?> getUserInputTask = Task.Run(() => Console.ReadLine());

    try
    {
        string? result = await Task.WhenAny(getUserInputTask, Task.Delay(timeout * 1000)) == getUserInputTask ? getUserInputTask.Result : null;

        stopwatch.Stop();
        if (result != null && int.TryParse(result, out response))
        {
            Console.WriteLine($"time taken to answer: {stopwatch.Elapsed.ToString(@"m\::ss\.ff")}");
            return response;
        }
        else
        {
            throw new OperationCanceledException();
        }
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Time is up.");
        return null;
    }
}

static int ValidateResult(int result,int? userResponse, int score)
{
    if (result == userResponse)
    {
        Console.WriteLine("You answer correctly; You earned 5 points");
        score += 5;
    }
    else
    {
        Console.WriteLine("Try again!");
        Console.WriteLine($"Correct answer is: {result}");
    }
    return score;
}
static async Task<int> PerformOperation(MathGameLogic mathGame, int firstNumber,int secondNumber,int score,char operaion,DifficultyLevel difficulty)
{
    int result;
    int? userResponse;
    DisplayMathGameQuestion(firstNumber, secondNumber, operaion);
    result = mathGame.MathOperation(firstNumber, secondNumber, operaion);
    userResponse = await GetUserResponse(difficulty);
    score += ValidateResult(result, userResponse, score);
    return score;
}
public enum DifficultyLevel
{
    Easy = 45,
    Medium = 30,
    Hard = 15
}