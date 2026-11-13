using System.Diagnostics;

namespace MathGame;

public static class Game
{
    private static List<(int, TimeSpan)> games = [];
    private readonly static string[] mathOperators = ["+", "-", "*", "/"];
    private static readonly Random random = new();
    private static DifficultyLevel difficultyLevel = DifficultyLevel.Easy;

    public static void PlayRound()
    {
        int points = 0;

        difficultyLevel = Menu.ChooseOperationDifficulty();

        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < 5; i++)
        {
            Operation operation = Menu.ChooseOperation();
            SolveEquation(ref points, operation);
        }

        sw.Stop();

        Console.WriteLine($"\nPoints for this round: {points}");
        Console.WriteLine($"Time spent: {sw.Elapsed:hh\\:mm\\:ss\\.fff}");

        games.Add((points, sw.Elapsed));
    }

    public static void ShowHistory()
    {
        if (games.Count == 0)
            Console.WriteLine("No games yet");

        for (int i = 0; i < games.Count; i++)
        {
            Console.WriteLine($"Points gained in {i + 1} game : {games[i].Item1}");
            Console.WriteLine($"Time spent on {i + 1} game : {games[i].Item2:hh\\:mm\\:ss\\.fff}");
        }
        Console.WriteLine();
    }

    private static (int, int) GenerateNumbers(Operation operation)
    {
        int num1 = 0, num2 = 0;
        switch (difficultyLevel)
        {
            case DifficultyLevel.Easy:
                num1 = random.Next(0, 10);
                num2 = random.Next(0, 10);
                break;
            case DifficultyLevel.Intermediate:
                num1 = random.Next(0, 100);
                num2 = random.Next(0, 100);
                break;
            case DifficultyLevel.Advanced:
                num1 = random.Next(0, 1000);
                num2 = random.Next(0, 1000);
                break;
        }


        if (operation == Operation.Division && (num2 == 0 || num1 % num2 != 0 || num1 > num2))
            return GenerateNumbers(operation);

        return (num1, num2);
    }

    private static void SolveEquation(ref int points, Operation operation)
    {
        (int num1, int num2) = GenerateNumbers(operation);

        Console.Write($"{num1} {mathOperators[(int)operation - 1]} {num2} = ");

        int result = GetAnswer();

        switch (operation)
        {
            case Operation.Addition:
                if (result == num1 + num2)
                    points++;
                break;
            case Operation.Substraction:
                if (result == num1 - num2)
                    points++;
                break;
            case Operation.Multiplication:
                if (result == num1 * num2)
                    points++;
                break;
            case Operation.Division:
                if (result == num1 / num2)
                    points++;
                break;
        }
    }

    private static int GetAnswer()
    {
        bool userInput = int.TryParse(Console.ReadLine(), out int result);

        if (!userInput)
        {
            Console.Write("Incorrect format. Try again: ");
            return GetAnswer();
        }
        return result;
    }
}