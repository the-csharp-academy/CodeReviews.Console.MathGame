namespace MathGame;

public static class Menu
{
    public static string StartMenu()
    {
        string? input;

        Console.WriteLine("Play");
        Console.WriteLine("History");
        Console.WriteLine("Exit");

        Console.Write("Enter your choise => ");

        input = Console.ReadLine();
        if (input is null)
        {
            Console.WriteLine("Your input is incorrect");
            return StartMenu();
        }

        return input;
    }
    public static Operation ChooseOperation()
    {
        string? input;

        Console.WriteLine();
        Console.WriteLine("Choose an operation: ");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Substraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.Write("Enter your choise => ");

        input = Console.ReadLine();
        if (input == string.Empty || !Enum.TryParse(input, out Operation operation) || !Enum.IsDefined(operation))
        {
            Console.WriteLine("Your input is incorrect");
            return ChooseOperation();
        }

        return operation;
    }
}