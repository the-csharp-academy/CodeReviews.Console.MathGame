/*
Requirements:

You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.

A game needs to have at least 5 questions.

The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.

Users should be presented with a menu to choose an operation

You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

You don't need to record results on a database. Once the program is closed the results will be deleted.
*/
Random rand = new();

int questionsAsked = 0;
int correctAnswers = 0;
bool exit = false;
List<string> history = [];

int numberOfQuestions = rand.Next(5, 10);

Console.WriteLine(
    $"Welcome to the Math Game! Answer {numberOfQuestions} questions and see how many you get right!"
);

do
{
    ShowMenu();

    int userSelection = MenuSelection();

    if (userSelection < 1 || userSelection > 7)
    {
        Console.WriteLine("Selection out of bounds. Selected option must be between 1 and 6");
        userSelection = MenuSelection();
    }

    HandleUserSelection(userSelection);
} while (questionsAsked < numberOfQuestions && !exit);

void ShowMenu()
{
    Console.WriteLine(
        $"Choose what you would like to do, you have {numberOfQuestions - questionsAsked} questions left!"
    );
    Console.WriteLine("1. Solve addition problems.");
    Console.WriteLine("2. Solve subtraction problems.");
    Console.WriteLine("3. Solve multiplication problems.");
    Console.WriteLine("4. Solve division problems.");
    Console.WriteLine("5. Give me a random problem.");
    Console.WriteLine("6. Show game history.");
    Console.WriteLine("7. Quit game.");
}

static int MenuSelection()
{
    int userSelection;

    while (!int.TryParse(Console.ReadLine(), out userSelection))
    {
        Console.WriteLine("Invalid selection, try again: ");
    }

    return userSelection;
}

void HandleUserSelection(int selectedOption)
{
    switch (selectedOption)
    {
        case 1:
        {
            int solution = MathQuestion("add");
            HandleUserAnswer(solution);
            break;
        }
        case 2:
        {
            int solution = MathQuestion("subtract");
            HandleUserAnswer(solution);
            break;
        }
        case 3:
        {
            int solution = MathQuestion("multiply");
            HandleUserAnswer(solution);
            break;
        }
        case 4:
        {
            int solution = MathQuestion("divide");
            HandleUserAnswer(solution);
            break;
        }
        case 5:
        {
            string[] mathOperation = ["add", "subtract", "divide", "multiply"];

            string randomOperation = mathOperation[rand.Next(0, mathOperation.Length - 1)];

            int solution = MathQuestion(randomOperation);
            HandleUserAnswer(solution);
            break;
        }
        case 6:
        {
            Console.WriteLine("Previous questions:");
            foreach (string item in history)
            {
                Console.WriteLine(item);
            }
            return;
        }
        case 7:
        {
            exit = true;
            Console.WriteLine("Hope to see you again soon!");
            break;
        }
        default:
        {
            // Add error
            break;
        }
    }
}

int MathQuestion(string selectedOperation)
{
    int intOne = rand.Next(0, 100);
    int intTwo = rand.Next(1, 10);

    int correctSolution;

    switch (selectedOperation)
    {
        case "add":
        {
            correctSolution = intOne + intTwo;
            Console.WriteLine($"What is {intOne} + {intTwo}?");
            history.Add($"{intOne}+{intTwo}={correctSolution}");
            break;
        }
        case "subtract":
        {
            correctSolution = intOne - intTwo;
            Console.WriteLine($"What is {intOne} - {intTwo}?");
            history.Add($"{intOne}-{intTwo}={correctSolution}");
            break;
        }
        case "multiply":
        {
            correctSolution = intOne * intTwo;
            Console.WriteLine($"What is {intOne} * {intTwo}?");
            history.Add($"{intOne}*{intTwo}={correctSolution}");
            break;
        }
        case "divide":
        {
            double resultCheck = (double)intOne / intTwo % 1;

            while (resultCheck != 0)
            {
                intOne = rand.Next(0, 100);
                intTwo = rand.Next(1, 10);

                resultCheck = (double)intOne / intTwo % 1;
            }

            correctSolution = intOne / intTwo;
            Console.WriteLine($"What is {intOne} / {intTwo}?");
            history.Add($"{intOne}/{intTwo}={correctSolution}");
            break;
        }
        default:
        {
            correctSolution = -99;
            break;
        }
    }

    return correctSolution;
}

void HandleUserAnswer(int correctSolution)
{
    int userAnswer;

    while (!int.TryParse(Console.ReadLine(), out userAnswer))
    {
        Console.WriteLine("Invalid number, try again: ");
    }

    if (userAnswer == correctSolution)
    {
        correctAnswers++;
        Console.WriteLine($"Well done, {userAnswer} is correct!");
    }
    else
    {
        Console.WriteLine(
            $"{userAnswer} was unfortunately not correct. The correct answer is {correctSolution}"
        );
    }

    questionsAsked++;

    if (numberOfQuestions == questionsAsked)
    {
        Console.WriteLine(
            $"Well done, you answered all {numberOfQuestions} questions! You got {correctAnswers} correct!"
        );
    }

    Console.WriteLine("--------------------------------------");
}
