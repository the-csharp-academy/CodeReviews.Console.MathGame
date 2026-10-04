using System;
using Math_Game;


Console.WriteLine(@" __        __   _                               _          _   _            __  __       _   _      ____                      _ 
 \ \      / /__| | ___ ___  _ __ ___   ___     | |_ ___   | |_| |__   ___  |  \/  | __ _| |_| |__  / ___| __ _ _ __ ___   ___  | |
  \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \    | __/ _ \  | __| '_ \ / _ \ | |\/| |/ _` | __| '_ \| |  _ / _` | '_ ` _ \ / _ \ | |
   \ V  V /  __/ | (_| (_) | | | | | |  __/    | || (_) | | |_| | | |  __/ | |  | | (_| | |_| | | | |_| | (_| | | | | | |  __/ |_|
    \_/\_/ \___|_|\___\___/|_| |_| |_|\___|     \__\___/   \__|_| |_|\___| |_|  |_|\__,_|\__|_| |_|\____|\__,_|_| |_| |_|\___| (_)
");






Console.WriteLine("Please Enter your Name");
string name = Console.ReadLine();
bool isPlaying = true;

var games = new List<string>();

while (isPlaying)
{
    
    Console.WriteLine($"Hello, {name}! Let's start the game.");
    Console.WriteLine("What Game would you like to play?");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Previous Game Score");
    Console.WriteLine("6. Exit");

    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
                Addition addition = new Addition();
                addition.Start(games);
                break;
            case 2:
                Subtraction subtraction = new Subtraction();
                subtraction.Start(games);
                break;
            case 3:
                Multiplication multiplication = new Multiplication();
                multiplication.Start(games);
                break;
            case 4:
                Division division = new Division();
                division.Start(games);
                break;

            case 5:
                PreviousGameScore previousGameScore = new PreviousGameScore();
                previousGameScore.Start(games);
                break;

        case 6:
            Console.WriteLine("Thank you for playing!");
            isPlaying = false;
            break;
        
        

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}