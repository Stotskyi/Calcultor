using Calculator.BLL.Commands.Abstractions;

namespace Calculator.BLL.Commands;

public class MultiplyCommand : BaseCommand
{
    public override double Execute(double a, double b)
    {
        return ExecuteWithHandling(() => a * b);
    }
}