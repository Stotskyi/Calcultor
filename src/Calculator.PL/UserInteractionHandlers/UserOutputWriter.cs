using Spectre.Console;

namespace Calculator.PL.UserInteractionHandlers;

public static class UserOutputWriter
{
    public static void WriteNumber(double number) => AnsiConsole.MarkupLine($"[bold green]Result: {number}[/]");
}