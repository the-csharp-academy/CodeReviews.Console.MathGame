using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {
        static List<Game> games = new();
        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNum = random.Next(0, 99);
            var secondNum = random.Next(0, 99);

            var result = new int[2];

            while (firstNum % secondNum != 0)
            {
                firstNum = random.Next(0, 99);
                secondNum = random.Next(0, 99);
            }

            result[0] = firstNum;
            result[1] = secondNum;

            Console.WriteLine(result);

            return result;
        }

        internal static void QuitGame(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(1);
        }

        internal static void AddToHistory(int score, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = score,
                Type = gameType
            });
        }

        internal static void PrintGames()
        {
            Console.WriteLine("Games history");
            Console.WriteLine("-------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
            }
            Console.WriteLine("-------------");
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadLine();
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Answer needs to be an integer. Please try again.");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Type your name: ");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty");
                name = Console.ReadLine();
            }
            return name;
        }
    }
}
