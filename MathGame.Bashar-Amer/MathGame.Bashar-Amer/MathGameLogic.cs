namespace MathGame.Bashar_Amer;

internal class MathGameLogic
{
    public List<string> GameHistory { get; set; } = new();

    public void ShowMenu()
    {
        Console.WriteLine("Please enter an option to select operation:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Random Mode");
        Console.WriteLine("6. Show History");
        Console.WriteLine("7. Change difficulty");
        Console.WriteLine("8. Exist");
        Console.WriteLine("--------------------");
    }

    public int CalculateMathOperation(int firstNumber, int secondNumber, char operation)
    {
        switch (operation)
        {
            case '+':
                GameHistory.Add($"firstNumber + secondNumber = {firstNumber + secondNumber}");
                return firstNumber + secondNumber;
            case '-':
                GameHistory.Add($"firstNumber - secondNumber = {firstNumber - secondNumber}");
                return firstNumber - secondNumber;
            case '*':
                GameHistory.Add($"firstNumber * secondNumber = {firstNumber * secondNumber}");
                return firstNumber * secondNumber;
            case '÷':
                while (firstNumber < 0 || firstNumber > 100)
                {
                    try {
                        Console.WriteLine("Please enter between 0 and 100.");
                        firstNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception) 
                    { }
                    
                }
                GameHistory.Add($"firstNumber / secondNumber = {firstNumber / secondNumber}");
                return firstNumber / secondNumber;
        }
        return 0;
    }
}
