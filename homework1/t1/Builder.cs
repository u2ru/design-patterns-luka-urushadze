namespace design_patterns_luka_urushadze.Homework1;

public class Car
{
    public string Engine { get; set; }
    public int Wheels { get; set; }
    public string Color { get; set; }

    public void Display()
    {
        Console.WriteLine($"Car = {Engine}, {Wheels}, {Color}");
    }
}

public interface ICarBuilder
{
    void BuildEngine();
    void BuildWheels();
    void BuildColor();
    Car GetCar();
}

public class SportsCarBuilder : ICarBuilder
{
    private Car _car = new Car();

    public void BuildEngine()
    {
        _car.Engine = "3.0L V6";
    }

    public void BuildWheels()
    {
        _car.Wheels = 4;
    }

    public void BuildColor()
    {
        _car.Color = "Red";
    }

    public Car GetCar()
    {
        return _car;
    }
}