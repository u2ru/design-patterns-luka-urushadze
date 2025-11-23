namespace task1.Decorator;

public class DecoratorExample
{
    public static void Execute()
    {
        Console.WriteLine("Decorator Pattern:");
        
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()}: ${coffee.GetCost()}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()}: ${coffee.GetCost()}");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()}: ${coffee.GetCost()}");
    }
}