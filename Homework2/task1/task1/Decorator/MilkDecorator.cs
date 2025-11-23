namespace task1.Decorator;

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return coffee.GetDescription() + ", milk";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 0.5;
    }
}