using System;
using static MathGame.Simof287.MathGameLogic; 

bool gameEnded = false;
int totalScore = 0;

do
{
    PrintMenu(totalScore);
    MenuOption choice = GetUserChoice();
    //Console.WriteLine($"echo: {choice}");
    switch (choice)
    {
        case MenuOption.ADD:
            totalScore += StartGame('+');
            break;
        case MenuOption.SUB:
            totalScore += StartGame('-');
            break;
        case MenuOption.MUL:
            totalScore += StartGame('*');
            break;
        case MenuOption.DIV:
            totalScore += StartGame('/');
            break;
        case MenuOption.HISTORY:
            PrintHistory();
            break;
        case MenuOption.ESC:
        default:
            gameEnded = true;
            Console.WriteLine("Have a good day!");
            break;
    }    
}while(!gameEnded);
