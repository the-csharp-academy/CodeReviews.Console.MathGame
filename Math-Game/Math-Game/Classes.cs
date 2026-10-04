using System;


namespace Math_Game
{
    internal class Addition
    {
        public void Start(List<string> games)
        {
            Console.WriteLine("How many questions would you like to answer?");
            int numberOfQuestions = int.Parse(Console.ReadLine());
            Random random = new Random();
            int score = 0;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                int num1 = random.Next(1, 100);
                int num2 = random.Next(1, 100);
                int answer = num1 + num2;
                Console.WriteLine($"What is {num1} + {num2}?");
                int userAnswer = int.Parse(Console.ReadLine());
                if (userAnswer == answer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {answer}.");
                }
            }
            Console.WriteLine($"Your score is {score} out of {numberOfQuestions}.");
            games.Add($"Addition - score is {score}");
            Console.WriteLine("");

        }

    }

    internal class Subtraction
    {
        public void Start(List<string> games)
        {
            Console.WriteLine("How many questions would you like to answer?");
            int numberOfQuestions = int.Parse(Console.ReadLine());
            Random random = new Random();
            int score = 0;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                int num1 = random.Next(1, 100);
                int num2 = random.Next(1, 100);
                int answer = Math.Abs(num1 - num2);
                Console.WriteLine($"What is {num1} - {num2}?");
                int userAnswer = int.Parse(Console.ReadLine());
                if (userAnswer == answer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {answer}.");
                }
            }
            Console.WriteLine($"Your score is {score} out of {numberOfQuestions}.");
            games.Add($"Subtraction - score is {score}");
        }
    }

    internal class Multiplication
    {
        public void Start(List<string> games)
        {
            Console.WriteLine("How many questions would you like to answer?");
            int numberOfQuestions = int.Parse(Console.ReadLine());
            Random random = new Random();
            int score = 0;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                int num1 = random.Next(1, 100);
                int num2 = random.Next(1, 100);
                int answer = num1 * num2;
                Console.WriteLine($"What is {num1} * {num2}?");
                int userAnswer = int.Parse(Console.ReadLine());
                if (userAnswer == answer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {answer}.");
                }
            }
            Console.WriteLine($"Your score is {score} out of {numberOfQuestions}.");
            games.Add($"Multiplication - score is {score}");
        }
    }

    internal class Division
    {
        public void Start(List<string> games)
        {
            Console.WriteLine("How many questions would you like to answer?");
            int numberOfQuestions = int.Parse(Console.ReadLine());
            Random random = new Random();
            int score = 0;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                int num1, num2;
                do
                {
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 100);
                } while (num1 % num2 != 0);

                int answer = num1 / num2;
                Console.WriteLine($"What is {num1} / {num2}?");
                int userAnswer = int.Parse(Console.ReadLine());
                if (userAnswer == answer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {answer}.");
                }
            }
            Console.WriteLine($"Your score is {score} out of {numberOfQuestions}.");
            games.Add($"Division - score is {score}");
        }
    }

    internal class PreviousGameScore
    {
        public void Start(List<string> games) 
        {
            Console.WriteLine("Here are your previous game scores:");
            if (games.Count == 0)
            {
                Console.WriteLine("No games have been played yet.");
            }
            else
            {
                foreach (var game in games)
                {
                    Console.WriteLine(game);
                }
            }

        }

    }

}
