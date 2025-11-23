namespace task1.Decorator;

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return coffee.GetDescription() + ", sugar";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 0.2;
    }
}