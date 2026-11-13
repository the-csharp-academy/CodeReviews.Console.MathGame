using MathGame;

Console.WriteLine("Welcome to math game!");

string input;
do
{
    input = Menu.StartMenu().Trim().ToLower();

    switch (input)
    {
        case "play":
            Console.Clear();
            Game.PlayRound();
            break;
        case "history":
            Console.Clear();
            Game.ShowHistory();
            break;
        case "exit":
            Console.WriteLine("Thanks for the game!");
            break;
        default:
            Console.WriteLine("Your input is incorrect");
            break;
    }

} while (input != "exit");
