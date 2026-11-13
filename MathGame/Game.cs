namespace MathGame;

public static class Game
{
    private static List<int> games = [];
    private readonly static string[] mathOperators = ["+", "-", "*", "/"];
    private static readonly Random random = new();

    public static void PlayRound()
    {
        int points = 0;

        for (int i = 0; i < 5; i++)
        {
            Operation operation = Menu.ChooseOperation();
            SolveEquation(ref points, operation);
        }

        Console.WriteLine($"\nPoints for this round: {points}");

        games.Add(points);
    }

    public static void ShowHistory()
    {
        if (games.Count == 0)
            Console.WriteLine("No games yet");

        for (int i = 0; i < games.Count; i++)
            Console.WriteLine($"Points gained in {i + 1} game : {games[i]}");

        Console.WriteLine();
    }

    private static (int, int) GenerateNumbers(Operation operation)
    {
        int num1 = random.Next(0, 10);
        int num2 = random.Next(0, 10);

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