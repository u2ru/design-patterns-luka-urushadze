namespace task1.Decorator;

public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;

    protected CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public virtual string GetDescription()
    {
        return coffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return coffee.GetCost();
    }
}