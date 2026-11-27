//Prepared questions, at least 5 for each operation
string[,] questions = {
    { "2", "*", "2" },
    { "4", "/", "2" },
    { "7", "*", "7" },
    { "39", "+", "11" },
    { "45", "-", "17" },
    { "99", "+", "74" },
    { "80", "-", "77" },
    { "3", "*", "17" },
    { "54", "-", "16" },
    { "35", "+", "18" },
    { "16", "/", "4" },
    { "55", "/", "5" },
    { "28", "+", "61" },
    { "49", "-", "7" },
    { "5", "*", "8" },
    { "77", "-", "13" },
    { "80", "/", "8" },
    { "12", "+", "80" },
    { "75", "/", "5" },
    { "13", "*", "12" },
};

//Operators
char[] operators = { '+', '-', '*', '/' };

//How many rounds are played with random questions
int randomRounds = 5;

//Match history list
var historyList = new List<History>();

//Random
Random rand = new Random();


MainMenu();

//Main menu
void MainMenu()
{
    string? userInput;
    bool validInput = false;
    int userChoice = 0;

    while (!validInput)
    {
        Console.Clear();
        Console.WriteLine("MAIN MENU");
        Console.WriteLine("1. Play prepared questions");
        Console.WriteLine("2. Play random questions");
        Console.WriteLine("3. View history");
        Console.WriteLine("4. Exit");
        userInput = Console.ReadLine();

        if (userInput != null && userInput != "")
        {
            userInput = userInput.Trim();
            validInput = int.TryParse(userInput, out userChoice);
        }
        if (validInput)
        {
            switch (userChoice)
            {
                case 1:
                    PlayPreparedQuestions();
                    break;
                case 2:
                    PlayRandomQuestions();
                    break;
                case 3:
                    ViewHistory();
                    break;
                case 4:
                    //The program exits
                    break;
                default:
                    //Pressing anything but 1, 2, 3, or 4 will keep the player in this loop
                    validInput = false;
                    break;
            }
        }
    }
}

//Operation choice for both prepared and random games, returns an operator symbol or "all"
string OperationChoice()
{
    string? userInput;
    bool validInput = false;
    int userChoice = 0;

    while (!validInput)
    {
        Console.Clear();
        Console.WriteLine("OPERATION SETTINGS");
        Console.WriteLine("1. Add (+)");
        Console.WriteLine("2. Subtract (-)");
        Console.WriteLine("3. Multiply (*)");
        Console.WriteLine("4. Divide (/)");
        Console.WriteLine("5. All operations (+, -, *, /)");
        userInput = Console.ReadLine();

        if (userInput != null && userInput != "")
        {
            userInput = userInput.Trim();
            validInput = int.TryParse(userInput, out userChoice);
        }
        if (validInput)
        {
            switch (userChoice)
            {
                case 1:
                    return "+";
                case 2:
                    return "-";
                case 3:
                    return "*";
                case 4:
                    return "/";
                case 5:
                    return "all";
                default:
                    validInput = false;
                    break;
            }
        }
    }
    return "all";
}

//Difficulty settings for random games
int difficultyChoice()
{
    string? userInput;
    bool validInput = false;
    int userChoice = 0;

    while (!validInput)
    {
        Console.Clear();
        Console.WriteLine("DIFFICULTY SETTINGS");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");
        Console.WriteLine("4. Nightmare");
        Console.WriteLine("5. Random");
        userInput = Console.ReadLine();

        if (userInput != null && userInput != "")
        {
            userInput = userInput.Trim();
            validInput = int.TryParse(userInput, out userChoice);
        }
        if (validInput)
        {
            switch (userChoice)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;
                case 5:
                    return 5;
                default:
                    validInput = false;
                    break;
            }
        }
    }
    return 5;
}

//Round history
void ViewHistory()
{
    Console.Clear();
    for (int i = 0; i < historyList.Count; i++)
    {
        Console.WriteLine($"Round {historyList[i].roundID}: {historyList[i].time} - {historyList[i].mode}: {historyList[i].question} = {historyList[i].usrResult}, correct: {historyList[i].correctAnswer}, duration: {historyList[i].duration.Minutes}:{historyList[i].duration.Seconds}");
    }
    Console.WriteLine("Press any key to return to the main menu.");
    Console.ReadKey();
    MainMenu();
}

//Starter for prepared questions
void PlayPreparedQuestions()
{
    string operation = OperationChoice();
    int score = 0;
    int currentRound = 1;
    DateTime startTime = DateTime.Now;
    for (int i = 0; i < (questions.Length / 3); i++)
    {
        if (questions[i, 1] == operation || operation == "all")
        {
            //PlayRound is called with "all" operations, because they are already filtered by "if (questions[i,1] == operation || operation == "all")" above
            if (PlayRound(i, false, "all", currentRound))
            {
                score++;
            }
            currentRound++;
        }
        else
        {
            //If the current question doesn't match the chosen operation, skip to the next one
            continue;
        }

    }
    TimeSpan duration = DateTime.Now - startTime;
    Console.Clear();
    Console.WriteLine($"All rounds finished! {score}/{currentRound - 1} correct.");
    Console.WriteLine($"It took you {duration.Minutes}:{duration.Seconds} to finish.");
    Console.WriteLine("Press any key to return to the main menu.");
    Console.ReadKey();
    MainMenu();
}

//Starter for random questions
void PlayRandomQuestions()
{
    string operation = OperationChoice();
    int difficulty = difficultyChoice();
    int score = 0;
    DateTime startTime = DateTime.Now;
    for (int i = 0; i < randomRounds; i++)
    {
        if (PlayRound(i, true, operation, i + 1, difficulty))
        {
            score++;
        }
    }
    TimeSpan duration = DateTime.Now - startTime;
    Console.Clear();
    Console.WriteLine($"All rounds finished! {score}/{randomRounds} correct.");
    Console.WriteLine($"It took you {duration.Minutes}:{duration.Seconds} to finish.");
    Console.WriteLine("Press any key to return to the main menu.");
    Console.ReadKey();
    MainMenu();
}

//Calculating result for the current question, a return value of -200 means that the supplied digits form an invalid question (ie dividing by zero, divisions that result in a decimal number, or an invalid operator)
int CalculateResult(int firstDigit, int secondDigit, string oper)
{
    switch (oper)
    {
        case "+":
            return (firstDigit + secondDigit);
        case "-":
            return (firstDigit - secondDigit);
        case "*":
            return (firstDigit * secondDigit);
        case "/":
            if (secondDigit == 0)
            {
                return -200;
            }
            if (firstDigit % secondDigit != 0)
            {
                return -200;
            }
            return (firstDigit / secondDigit);
        default:
            return -200;
    }
}

//Method for playing a round, both random and prepared
bool PlayRound(int index = 0, bool random = false, string operation = "all", int currentRound = 1, int difficulty = 5)
{

    string? userInput;
    bool validInput = false;
    int userResult = 0;
    int result = 0;
    int firstDigit = 0;
    int secondDigit = 0;
    string oper = "";
    string modeNow = "";
    bool correct = false;

    //If it's not a random game, get the digits and operator from the prepared list
    if (!random)
    {
        firstDigit = Convert.ToInt32(questions[index, 0]);
        secondDigit = Convert.ToInt32(questions[index, 2]);
        oper = questions[index, 1];
        modeNow = "prepared";
    }
    //If it is a random game, either pick an operator based on settings, or pick one at random if set to "all"
    else
    {
        modeNow = "random";
        switch (operation)
        {
            case "+":
                oper = operators[0].ToString();
                break;
            case "-":
                oper = operators[1].ToString();
                break;
            case "*":
                oper = operators[2].ToString();
                break;
            case "/":
                oper = operators[3].ToString();
                break;
            case "all":
                oper = operators[rand.Next(0, 4)].ToString();
                break;
            default:
                oper = operators[rand.Next(0, 4)].ToString();
                break;
        }

        //Generating random digits for a game based on the difficulty setting, keep trying until CalculateResult returns a value that's not -200
        do
        {
            switch (difficulty)
            {
                case 1:
                    firstDigit = rand.Next(0, 21);
                    secondDigit = rand.Next(0, 21);
                    break;
                case 2:
                    firstDigit = rand.Next(20, 76);
                    secondDigit = rand.Next(20, 76);
                    break;
                case 3:
                    firstDigit = rand.Next(50, 101);
                    secondDigit = rand.Next(50, 101);
                    break;
                case 4:
                    firstDigit = rand.Next(75, 101);
                    secondDigit = rand.Next(75, 101);
                    break;
                case 5:
                    firstDigit = rand.Next(0, 101);
                    secondDigit = rand.Next(0, 101);
                    break;
                default:
                    firstDigit = rand.Next(0, 101);
                    secondDigit = rand.Next(0, 101);
                    break;
            }
        } while (CalculateResult(firstDigit, secondDigit, oper) == -200);
    }

    //In both random and prepared games, valid digits have been assigned by now, calculate the result
    result = CalculateResult(firstDigit, secondDigit, oper);

    //Start the timer and ask the player to answer the question
    DateTime startTime = DateTime.Now;
    while (!validInput)
    {
        Console.Clear();
        Console.Write($"Round {currentRound}: {firstDigit} {oper} {secondDigit} = ");
        userInput = Console.ReadLine();

        if (userInput != null && userInput != "")
        {
            userInput = userInput.Trim();
            validInput = int.TryParse(userInput, out userResult);
        }
    }

    //If the answer was correct
    if (userResult == result)
    {
        correct = true;
        Console.WriteLine($"Congratulations! The answer is {result}");
    }
    //If the answer was incorrect
    else
    {
        correct = false;
        Console.WriteLine($"The answer is {result}, not {userResult}");
    }

    //Add game to history
    historyList.Add(new History
    {
        roundID = currentRound,
        time = (DateTime.Now).ToString(),
        mode = modeNow,
        question = firstDigit.ToString() + " " + oper + " " + secondDigit.ToString(),
        usrResult = userResult,
        correctAnswer = correct,
        duration = (DateTime.Now - startTime)
    });
    Console.WriteLine("press any key to continue");
    Console.ReadKey();
    return correct;
}

//History list class
public class History
{
    public int roundID { get; set; }

    public string time { get; set; }
    public string mode { get; set; }
    public string question { get; set; }
    public int usrResult { get; set; }
    public bool correctAnswer { get; set; }
    public TimeSpan duration { get; set; }
}