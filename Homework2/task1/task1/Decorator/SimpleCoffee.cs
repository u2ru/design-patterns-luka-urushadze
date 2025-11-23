namespace task1.Decorator;

public class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple coffee";
    }

    public double GetCost()
    {
        return 2.0;
    }
}