using System.Diagnostics;

List<GameResult> gameHistory = [];
var random = new Random();

while (true)
{
    Console.WriteLine("Math Game");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Random Game");
    Console.WriteLine("6. History");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");

    switch (Console.ReadLine())
    {
        case "1":
            PlayGame(ArithmeticOperation.Addition, gameHistory, random);
            break;
        case "2":
            PlayGame(ArithmeticOperation.Subtraction, gameHistory, random);
            break;
        case "3":
            PlayGame(ArithmeticOperation.Multiplication, gameHistory, random);
            break;
        case "4":
            PlayGame(ArithmeticOperation.Division, gameHistory, random);
            break;
        case "5":
            PlayGame(null, gameHistory, random);
            break;
        case "6":
            ShowHistory(gameHistory);
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Please choose a valid menu option.");
            break;
    }

    Console.WriteLine();
}

static void PlayGame(
    ArithmeticOperation? selectedOperation,
    List<GameResult> gameHistory,
    Random random)
{
    DifficultyLevel difficulty = ReadDifficulty();
    int questionCount = ReadQuestionCount();
    int maximumOperand = difficulty switch
    {
        DifficultyLevel.Easy => 10,
        DifficultyLevel.Medium => 50,
        DifficultyLevel.Hard => 100,
        _ => throw new InvalidOperationException("Unknown difficulty level.")
    };
    var score = 0;
    Stopwatch stopwatch = Stopwatch.StartNew();

    for (var questionNumber = 1; questionNumber <= questionCount; questionNumber++)
    {
        ArithmeticOperation operation = selectedOperation ?? (ArithmeticOperation)random.Next(0, 4);
        MathQuestion question = CreateQuestion(operation, maximumOperand, random);

        Console.WriteLine($"Question {questionNumber}/{questionCount}: {question.Prompt}");
        Console.Write("Your answer: ");
        string? answerText = Console.ReadLine();
        bool isValidAnswer = int.TryParse(answerText, out int answer);

        if (isValidAnswer && (answer == question.CorrectAnswer))
        {
            score++;
            Console.WriteLine("Correct!");
        }
        else if (isValidAnswer)
        {
            Console.WriteLine($"Incorrect. The answer was {question.CorrectAnswer}.");
        }
        else
        {
            Console.WriteLine($"Invalid answer. The answer was {question.CorrectAnswer}.");
        }
    }

    stopwatch.Stop();
    string mode = selectedOperation?.ToString() ?? "Random";
    var result = new GameResult(mode, difficulty, score, questionCount, stopwatch.Elapsed);
    gameHistory.Add(result);

    Console.WriteLine($"Game complete: {score}/{questionCount} correct.");
    Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalSeconds:F1} seconds.");
}

static DifficultyLevel ReadDifficulty()
{
    while (true)
    {
        Console.WriteLine("Choose difficulty: 1. Easy (0-10), 2. Medium (0-50), 3. Hard (0-100)");
        Console.Write("Difficulty: ");

        switch (Console.ReadLine())
        {
            case "1":
                return DifficultyLevel.Easy;
            case "2":
                return DifficultyLevel.Medium;
            case "3":
                return DifficultyLevel.Hard;
            default:
                Console.WriteLine("Please choose 1, 2, or 3.");
                break;
        }
    }
}

static int ReadQuestionCount()
{
    while (true)
    {
        Console.Write("Number of questions (minimum 5): ");
        if (int.TryParse(Console.ReadLine(), out int questionCount) && (questionCount >= 5))
        {
            return questionCount;
        }

        Console.WriteLine("Enter a whole number of at least 5.");
    }
}

static MathQuestion CreateQuestion(
    ArithmeticOperation operation,
    int maximumOperand,
    Random random)
{
    int firstOperand = random.Next(0, maximumOperand + 1);
    int secondOperand = random.Next(0, maximumOperand + 1);

    return operation switch
    {
        ArithmeticOperation.Addition => new MathQuestion(
            $"{firstOperand} + {secondOperand} = ?",
            firstOperand + secondOperand),
        ArithmeticOperation.Subtraction => CreateSubtractionQuestion(firstOperand, secondOperand),
        ArithmeticOperation.Multiplication => new MathQuestion(
            $"{firstOperand} x {secondOperand} = ?",
            firstOperand * secondOperand),
        ArithmeticOperation.Division => CreateDivisionQuestion(maximumOperand, random),
        _ => throw new InvalidOperationException("Unknown arithmetic operation.")
    };
}

static MathQuestion CreateSubtractionQuestion(int firstOperand, int secondOperand)
{
    int largerOperand = Math.Max(firstOperand, secondOperand);
    int smallerOperand = Math.Min(firstOperand, secondOperand);
    return new MathQuestion(
        $"{largerOperand} - {smallerOperand} = ?",
        largerOperand - smallerOperand);
}

static MathQuestion CreateDivisionQuestion(int maximumOperand, Random random)
{
    int dividend = random.Next(0, maximumOperand + 1);
    int[] possibleDivisors = dividend == 0
        ? Enumerable.Range(1, maximumOperand).ToArray()
        : Enumerable.Range(1, Math.Min(dividend, maximumOperand))
            .Where(divisor => dividend % divisor == 0)
            .ToArray();
    int divisor = possibleDivisors[random.Next(possibleDivisors.Length)];

    return new MathQuestion(
        $"{dividend} / {divisor} = ?",
        dividend / divisor);
}

static void ShowHistory(List<GameResult> gameHistory)
{
    if (gameHistory.Count == 0)
    {
        Console.WriteLine("No games have been completed yet.");
        return;
    }

    Console.WriteLine("Game history:");
    for (var index = 0; index < gameHistory.Count; index++)
    {
        GameResult result = gameHistory[index];
        Console.WriteLine($"{index + 1}. {result.Mode}, {result.Difficulty}: {result.Score}/{result.QuestionCount}, {result.Elapsed.TotalSeconds:F1} seconds");
    }
}

enum ArithmeticOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}

record MathQuestion(string Prompt, int CorrectAnswer);

record GameResult(
    string Mode,
    DifficultyLevel Difficulty,
    int Score,
    int QuestionCount,
    TimeSpan Elapsed);
