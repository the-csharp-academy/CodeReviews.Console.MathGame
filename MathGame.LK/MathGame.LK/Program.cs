bool gameRunning = true;
string userAnswer;
Random randomNum = new Random(); // single Random instance reused for the whole program
List<GameResult> gameResults = new(); // stores the score/total of every round played

Console.WriteLine("---Welcome to the Math game!---");
while (gameRunning) // main game loop - keeps running until the player quits
{
    // Ask the player to pick a math operation
    Console.WriteLine("Choose:\nA) Pick a math operation by number:\n 1 - addition\n 2 - subtraction\n 3 - multiplication\n 4 - division");
    Console.Write("Your choice: ");

    string operatorInput = Console.ReadLine() ?? "";

    // Validate operator choice; restart loop if invalid
    if (!int.TryParse(operatorInput, out int arithmeticOperator) || arithmeticOperator < 0 || arithmeticOperator > 4)
    {
        Console.WriteLine("\nInvalid number! Choose correctly!\n");
        continue;
    }

    // Ask how many questions the player wants to answer
    Console.WriteLine("\nChoose how many questions you want");
    Console.Write("Your choice: ");
    string numberInput = Console.ReadLine() ?? "";

    // Validate question count; restart loop if invalid
    if (!int.TryParse(numberInput, out int arithmeticNumber) || arithmeticNumber < 1)
    {
        Console.WriteLine("\nInvalid number of questions! Try again.\n");
        continue;
    }

    int totalQuestions = arithmeticNumber; // keep original count for later (score display, history)
    int userScore = 0;

    //Question loop until reaches 0
    do
    {
        int num1 = randomNum.Next(1, 11);
        int num2 = randomNum.Next(1, 11);
        string symbol = "";
        int result = 0;
        switch (arithmeticOperator)
        {
            case 1:
                result = num1 + num2;
                symbol = "+";
                break;
            case 2:
                result = num1 - num2;
                symbol = "-";
                break;
            case 3:
                result = num1 * num2;
                symbol = "*";
                break;
            case 4:
                // to guarantee a whole-number result
                result = randomNum.Next(1, 11);
                int divisor = randomNum.Next(1, 11);
                num1 = result * divisor;
                num2 = divisor;
                symbol = "/";
                break;
        }

        Console.WriteLine($"\n Calculate: {num1} {symbol} {num2} ...? ");
        Console.Write("Your answer: ");
        userAnswer = Console.ReadLine() ?? "";
        arithmeticNumber--; // one less question


        userScore = CorrectAnswer(userAnswer, userScore, result); // check answer and update score
    }
    while (arithmeticNumber > 0);

    gameResults.Add(new GameResult(userScore, totalQuestions)); // save this round's result to history

    // Ask if the player wants another round
    Console.Write($"Your score is: {userScore}/{totalQuestions} Want to play again? y/n: ");
    userAnswer = (Console.ReadLine() ?? "").ToLower();

    if (!string.IsNullOrEmpty(userAnswer) && userAnswer == "y")
    {
        Console.WriteLine($"\nLet's play again then!\n");
        continue; //go back to the top of the main loop
    }
    else
    {
        Console.WriteLine("\nOkay, thanks for playing!");
        break; //exit main loop
    }

}

Console.WriteLine("\n--- Game history ---");
for (int i = 0; i < gameResults.Count; i++)
{
    Console.WriteLine($"Round {i + 1}: {gameResults[i].Score}/{gameResults[i].Total}");
}

// Checks the players answer
static int CorrectAnswer(string userAnswer, int userScore, int result)
{
    if (int.TryParse(userAnswer, out int numAnswer) && result == numAnswer)
    {
        Console.WriteLine("\nCorrect, you're making progress!\n");
        userScore++;
    }
    else
        Console.WriteLine($"\nWrong, the correct answer is: {result}\n");
    return userScore;
}
//Positional record
record GameResult(int Score, int Total);
