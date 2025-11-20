namespace design_patterns_luka_urushadze;
using Homework1;

public class Program
{
    private static void Main(string[] args)
    {
        Singleton s1 = Singleton.GetInstance();
        Singleton s2 = Singleton.GetInstance();

        if (s1 == s2)
        {
            Console.WriteLine("Singleton works");
        }
        else
        {
            Console.WriteLine("Singleton failed");
        }
        
        // Prototype
        PrototypeExample p1 = new PrototypeExample("Luka");
        PrototypeExample p2 = p1.Clone();
        
        if (p1 != p2)
        {
            Console.WriteLine("Prototype works");
        }
        else
        {
            Console.WriteLine("Prototype failed");
        }
        
        // FactoryMethod
        BikeFactory bike = new BikeFactory("Mountain Bike", "Red");
        CarFactory car = new CarFactory("Sedan", "Blue");
        
        Console.WriteLine(bike.Paint);
        Console.WriteLine(car.Paint);
        
        // Abstract Factory
        IUIFactory iosFactory = new IOSFactory();
        Abstr app = new Abstr(iosFactory);
        app.Run();
        
        IUIFactory androidFactory = new AndroidFactory();
        Abstr app2 = new Abstr(androidFactory);
        app2.Run();
        
        // Builder
        SportsCarBuilder sportsCarBuilder = new SportsCarBuilder();
        sportsCarBuilder.BuildEngine();
        sportsCarBuilder.BuildWheels();
        sportsCarBuilder.BuildColor();
        Car sportsCar = sportsCarBuilder.GetCar();
        sportsCar.Display();
    }
}