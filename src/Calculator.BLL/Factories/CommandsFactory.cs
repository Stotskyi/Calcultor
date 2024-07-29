using Calculator.BLL.Commands;
using Calculator.BLL.Commands.Abstractions;

namespace Calculator.BLL.Factories;

public static  class CommandsFactory
{
    public static IActionCommand BuildActionCommand(int command)
        => command switch
        {
            1 => new AddCommand(),
            2 => new SubtractCommand(),
            3 => new MultiplyCommand(),
            4 => new DivideCommand(),
            _ => throw new ArgumentOutOfRangeException(nameof(command), command, null)
        };

}