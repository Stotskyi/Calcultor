namespace Calculator.BLL.Commands.Abstractions;

public interface IActionCommand
{ 
    public double Execute(double a, double b);
}