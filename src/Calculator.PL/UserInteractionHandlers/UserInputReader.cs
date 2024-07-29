using Calculator.BLL.Commands;
using Spectre.Console;

namespace Calculator.PL.UserInteractionHandlers;

public static class UserInputReader
{
    public static double ReadNumber()
    {
        double number;
        
        while (true)
        {
            Console.WriteLine("Enter your number: ");
            string input = Console.ReadLine()!;

            if (double.TryParse(input, out number))
            {
                return number;
            }

            AnsiConsole.MarkupLine("[bold red]Invalid input. Please enter a valid number.[/]");
        }

    }
}