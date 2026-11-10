namespace MathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string? name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------\n");
            Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself\n");
            Console.ReadLine();
            Console.WriteLine("\n");

            var isGameOn = true;

            do
            {
                Console.WriteLine($@"What game would you like to play today? Choose from the options below:

        A - Addition
        S - Substraction
        M - Multiplication
        D - Division
        V - View game history
        Q - Quit the program");

                Console.WriteLine("--------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        gameEngine.AdditionGame("Addition game selected");
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division game selected");
                        break;
                    case "s":
                        gameEngine.SubstractionGame("Substraction game selected");
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplication game selected");
                        break;
                    case "q":
                        Helpers.QuitGame("Bye-bye!");
                        isGameOn = false;
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        Environment.Exit(1);
                        break;
                }
            } while (isGameOn);
        }
    }
}
