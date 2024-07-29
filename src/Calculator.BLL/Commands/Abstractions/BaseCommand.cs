using Spectre.Console;

namespace Calculator.BLL.Commands.Abstractions;

public abstract class BaseCommand : IActionCommand
{
    public BaseCommand()
    {
        
    }
    protected double ExecuteWithHandling(Func<double> operation)
    {
        try
        {
            return operation();
        }
        catch (OverflowException ex)
        {
            AnsiConsole.MarkupLine($"[bold red]An overflow error occurred: {ex.Message}[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[bold red]An error occurred: {ex.Message}[/]");
        }

        return 0;
    }

    public abstract double Execute(double a, double b);
}