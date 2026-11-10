using MathGame.Models;

namespace MathGame
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;

            int firstNum;
            int secondNum;

            for (int i = 0; i < 5; i++)
            {
                firstNum = random.Next(1, 9);
                secondNum = random.Next(1, 9);

                Console.WriteLine($"{firstNum} + {secondNum}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNum + secondNum)
                {
                    Console.WriteLine("Answer was correct! Type any key to continue.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Answer is incorrect! Type any key to continue.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Final score is {score}. Press any key to return to main menu.");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Addition);
        }

        internal void SubstractionGame(string message)
        {
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;

            int firstNum;
            int secondNum;

            for (int i = 0; i < 5; i++)
            {
                firstNum = random.Next(1, 9);
                secondNum = random.Next(1, 9);

                Console.WriteLine($"{firstNum} - {secondNum}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNum - secondNum)
                {
                    Console.WriteLine("Answer was correct! Type any key to continue.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Answer is incorrect! Type any key to continue.");
                    Console.ReadLine();
                }

                if (i == 4)
                    Console.WriteLine($"Game over. Final score is {score}");
            }

            Helpers.AddToHistory(score, GameType.Substraction);
        }

        internal void MultiplicationGame(string message)
        {
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;

            int firstNum;
            int secondNum;

            for (int i = 0; i < 5; i++)
            {
                firstNum = random.Next(1, 9);
                secondNum = random.Next(1, 9);

                Console.WriteLine($"{firstNum} * {secondNum}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNum * secondNum)
                {
                    Console.WriteLine("Answer was correct! Type any key to continue.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Answer is incorrect! Type any key to continue.");
                    Console.ReadLine();
                }

                if (i == 4)
                    Console.WriteLine($"Game over. Final score is {score}");
            }

            Helpers.AddToHistory(score, GameType.Multiplication);
        }

        internal void DivisionGame(string message)
        {
            Console.WriteLine(message);
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstNum = divisionNumbers[0];
                var secondNum = divisionNumbers[1];

                Console.WriteLine($"{firstNum} / {secondNum}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNum / secondNum)
                {
                    Console.WriteLine("Answer was correct! Type any key to continue.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Answer is incorrect! Type any key to continue.");
                    Console.ReadLine();
                }

                if (i == 4)
                    Console.WriteLine($"Game over. Final score is {score}");
            }

            Helpers.AddToHistory(score, GameType.Division);
        }
    }
}
