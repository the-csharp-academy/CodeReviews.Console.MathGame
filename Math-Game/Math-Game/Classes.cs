using System;


namespace Math_Game
{
    internal class Addition
    {
        public void Start()
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
        }
    }

    internal class Subtraction
    {
        public void Start()
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
        }
    }

    internal class Multiplication
    {
        public void Start()
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
        }
    }

    internal class Division
    {
        public void Start()
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
        }
    }

}
