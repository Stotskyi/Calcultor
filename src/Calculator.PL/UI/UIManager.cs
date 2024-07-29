using Calculator.BLL.Factories;
using Calculator.PL.Model;
using Calculator.PL.UserInteractionHandlers;
using Serilog;
using Spectre.Console;

namespace Calculator.PL.UI;

public  class UIManager
{
    private readonly ILogger _logger;

    public UIManager(ILogger logger)
    {
        _logger = logger;
    }
    public  void DisplayActionPage()
    {
        _logger.Information("Displaying introduction");
        
        var option = GetAction();

        if (option == ActionOptions.Exit)
        {
            _logger.Information("Exiting application");
            AnsiConsole.MarkupLine("[bold green]Thank you for using the Console Calculator. Goodbye![/]");
            Environment.Exit(0);
        }
        
        var commandHandler = CommandsFactory.BuildActionCommand((int)option);
        _logger.Information($"Selected action: {option}");
        
        var result = commandHandler.Execute(UserInputReader.ReadNumber(), UserInputReader.ReadNumber());
        _logger.Information($"Executed command: {commandHandler.ToString()}");

        UserOutputWriter.WriteNumber(result);

    }
    public  void DisplayIntroduction()
    {
        AnsiConsole.Write(new FigletText("Console Calculator").Centered().Color(Color.Green));
        AnsiConsole.MarkupLine("[bold]Welcome to the Console Calculator![/]");
        AnsiConsole.MarkupLine("This calculator allows you to perform basic arithmetic operations.");
        AnsiConsole.MarkupLine("You can choose from the following operations:");
        AnsiConsole.MarkupLine("[green]1. Addition[/]");
        AnsiConsole.MarkupLine("[green]2. Subtraction[/]");
        AnsiConsole.MarkupLine("[green]3. Multiplication[/]");
        AnsiConsole.MarkupLine("[green]4. Division[/]");
        AnsiConsole.MarkupLine("[green]5. Exit[/]");
        AnsiConsole.MarkupLine("Follow the prompts to enter your numbers and see the result.");
    }

    private  ActionOptions GetAction()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<ActionOptions>()
                .Title("Login Page")
                .HighlightStyle(new Style(Color.Green)) 
                .AddChoices(
                    ActionOptions.Add,
                    ActionOptions.Subtract,
                    ActionOptions.Multiply,
                    ActionOptions.Divide,
                    ActionOptions.Exit));
    }
    
}