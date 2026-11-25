using System;

namespace MathGame.Simof287;

public static class MathGameLogic
{

    private static List<List<string>> gameHistory = new();    
    public enum MenuOption{ADD,SUB,MUL,DIV,HISTORY,ESC};

    public static void PrintMenu(int totalScore)
    {
        Console.Clear();
        Console.WriteLine("--------Math Game--------");
        Console.WriteLine($"Score: {totalScore}");
        Console.WriteLine("\n-----Choose an option-----\n");
        Console.WriteLine("------------------------------");
        Console.WriteLine("ADD - Addition\nSUB - Subtraction\nMUL - Multiplication\nDIV - Division");
        Console.WriteLine("HISTORY - Show previous games\nESC - End the game");
        Console.WriteLine("------------------------------");
    }

    public static MenuOption GetUserChoice()
    {
        MenuOption returnValue;
        bool success = false;
        do
        {    
        
        success = Enum.TryParse<MenuOption>(Console.ReadLine(), true, out returnValue);
            if (!success)
            {
                Console.WriteLine("Invalid Input");
            }
        }while(!success);

        return returnValue;
    }

    private static int GetUserResponse()
    {
        int returnValue;
        bool success = false;
        do
        {    
        
        success = int.TryParse(Console.ReadLine(), out returnValue);
            if (!success)
            {
                Console.WriteLine("Invalid Input");
            }
        }while(!success);

        return returnValue;
    }

    public static int StartGame(char operation)
    {
        Console.Clear();
        List<string> questionList = new();
        int points = 0;
        Random rand = new Random();
        int[] variable = new int[2];
        int inputResult;
        int expectedResult;

        Console.WriteLine("\n-----Game start!-----\n");

        for(int i = 0; i < 5; i++)
        {
            variable[0] = rand.Next(1,101);
            variable[1] = rand.Next(1,101);
            while(operation == '/' && variable[0]%variable[1]!=0)
            {
            variable[0] = rand.Next(1,101);
            variable[1] = rand.Next(1,101);   
            }
            Console.WriteLine($"{variable[0]} {operation} {variable[1]} = ?");
            inputResult = GetUserResponse();
            switch (operation)
            {
                case '+':
                    expectedResult = variable[0] + variable[1];
                    break;
                case '-':
                    expectedResult = variable[0] - variable[1];
                    break;
                case '*':
                    expectedResult = variable[0] * variable[1];
                    break;
                case '/':
                    expectedResult = variable[0] / variable[1];
                    break;
                default:
                    expectedResult = 0;
                    Console.WriteLine("Error, Invalid operator");
                    break;
            }
            if(inputResult == expectedResult)
            {
                Console.WriteLine("Correct! You earn 1 point.");
                points++;
                questionList.Add($"{variable[0]} {operation} {variable[1]} = {expectedResult} ✔");

            }
            else
            {
                Console.WriteLine("Wrong answer! You earn 0 point.");
                questionList.Add($"{variable[0]} {operation} {variable[1]} = {inputResult} ✖ [Correct answer: {expectedResult}]");
            }
    
        }
        gameHistory.Add(questionList);

        Console.WriteLine("\n-----Game ended!-----\n");
        Console.WriteLine("Press anything to continue.");
        Console.ReadKey();

        return points;

    }

    public static void PrintHistory()
    {
        Console.Clear();
        if (gameHistory.Count == 0)
        {
            Console.WriteLine("No games recorded yet\n");
        }
        else
        {
            
            for(int i = 0; i < gameHistory.Count; i++)
            {
                Console.WriteLine($"\n-----Game {i+1}-----\n");
                Console.WriteLine("------------------------------");
                List<string> questionList = gameHistory[i];
                foreach(string question in questionList)
                {
                    Console.WriteLine(question);
                }
                Console.WriteLine("------------------------------");
                Console.WriteLine("Press anything to continue.");
                Console.ReadKey();
            }
        }
    }
}
