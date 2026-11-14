namespace MathGame_CSharpAcademy
{
    public class MathGameLogic
    {
        public List<string> GameHistory { get; set; } = new List<string>();

        public void ShowMenu()
        {
            Console.WriteLine("Please enter an option to select an operation you want to perform.");
            Console.WriteLine("1. Summation");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random Mode");
            Console.WriteLine("6. Show History");
            Console.WriteLine("7. Change Difficulty");
            Console.WriteLine("8. Exit");
        }

        public int MathOperation(int firstNumber, int secondNumber, char operation)
        {
            switch (operation)
            {
                case '+':
                    GameHistory.Add($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                    return firstNumber + secondNumber;
                case '-':
                    GameHistory.Add($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                    return firstNumber - secondNumber;
                case '*':
                    GameHistory.Add($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                    return firstNumber * secondNumber;
                case '/':
                    while (firstNumber < 0 || firstNumber > 100)
                    {
                        try
                        {
                            Console.WriteLine("Please enter number between 0 and 100.");
                            firstNumber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (SystemException)
                        {
                            //do nothing
                        }
                    }
                    GameHistory.Add($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
                    return firstNumber / secondNumber;
            }
            return 0;
        }
    }
}