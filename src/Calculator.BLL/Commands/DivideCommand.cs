using Calculator.BLL.Commands.Abstractions;

namespace Calculator.BLL.Commands;

public class DivideCommand : BaseCommand
{
    public override double Execute(double a, double b)
    {
        return ExecuteWithHandling(() => a / b);
    }
}