using Calculator.BLL.Commands.Abstractions;

namespace Calculator.BLL.Commands;

public class SubtractCommand : BaseCommand
{
    public override double Execute(double a, double b)
    {
        return ExecuteWithHandling(() => a - b);
    }
}