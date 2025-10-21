using System.Collections.Generic;

namespace homework1_2;

abstract class Car
{
    public int Weight { get; set; }
    public int Length { get; set; }
    public int MaxSpeed { get; set; }

    public Car(int weight, int length, int maxSpeed)
    {
        Weight = weight;
        Length = length;
        MaxSpeed = maxSpeed;
    }

    public abstract void Display();
    public abstract Car Clone();
}

class Vehicle : Car
{
    public string WheelDrive { get; set; }
    public string VehicleClass { get; set; }
    public string Color { get; set; }

    public Vehicle(int weight, int length, int maxSpeed, string wheelDrive, string vehicleClass, string color) : base(weight, length, maxSpeed)
    {
        WheelDrive = wheelDrive;
        VehicleClass = vehicleClass;
        Color = color;
    }

    public override void Display()
    {
        Console.WriteLine($"Vehicle = {Weight}, {Length}, {MaxSpeed}, {WheelDrive}, {VehicleClass}, {Color}");
    }

    public override Car Clone()
    {
        return new Vehicle(this.Weight, this.Length, this.MaxSpeed, this.WheelDrive, this.VehicleClass, this.Color);
    }
}

class Cargo : Car
{
    public int Tonnage { get; set; }
    public int TankVolume { get; set; }
    public int AxlesAmount { get; set; }

    public Cargo(int weight, int length, int maxSpeed, int tonnage, int tankVolume, int axlesAmount) : base(weight, length, maxSpeed)
    {
        Tonnage = tonnage;
        TankVolume = tankVolume;
        AxlesAmount = axlesAmount;
    }

    public override void Display()
    {
        Console.WriteLine($"Cargo = {Weight}, {Length}, {MaxSpeed}, {Tonnage}, {TankVolume}, {AxlesAmount}");
    }

    public override Car Clone()
    {
        return new Cargo(this.Weight, this.Length, this.MaxSpeed, this.Tonnage, this.TankVolume, this.AxlesAmount);
    }
}

class Tank : Car
{
    public int Caliber { get; set; }
    public int ShotsPerMinute { get; set; }
    public int CrewSize { get; set; }

    public Tank(int weight, int length, int maxSpeed, int caliber, int shotsPerMinute, int crewSize) : base(weight, length, maxSpeed)
    {
        Caliber = caliber;
        ShotsPerMinute = shotsPerMinute;
        CrewSize = crewSize;
    }

    public override Car Clone()
    {
        return new Tank(this.Weight, this.Length, this.MaxSpeed, this.Caliber, this.ShotsPerMinute, this.CrewSize);
    }

    public override void Display()
    {
        Console.WriteLine($"Tank = {Weight}, {Length}, {MaxSpeed}, {Caliber}, {ShotsPerMinute}, {CrewSize}");
    }
}

class VehicleBuilder
{
    private int weight;
    private int length;
    private int maxSpeed;
    private string wheelDrive = "";
    private string vehicleClass = "";
    private string color = "";

    public VehicleBuilder SetWeight(int weight)
    {
        this.weight = weight;
        return this;
    }

    public VehicleBuilder SetLength(int length)
    {
        this.length = length;
        return this;
    }

    public VehicleBuilder SetMaxSpeed(int maxSpeed)
    {
        this.maxSpeed = maxSpeed;
        return this;
    }

    public VehicleBuilder SetWheelDrive(string wheelDrive)
    {
        this.wheelDrive = wheelDrive;
        return this;
    }

    public VehicleBuilder SetVehicleClass(string vehicleClass)
    {
        this.vehicleClass = vehicleClass;
        return this;
    }

    public VehicleBuilder SetColor(string color)
    {
        this.color = color;
        return this;
    }

    public Vehicle Build()
    {
        return new Vehicle(weight, length, maxSpeed, wheelDrive, vehicleClass, color);
    }
}

class CargoBuilder
{
    private int weight;
    private int length;
    private int maxSpeed;
    private int tonnage;
    private int tankVolume;
    private int axlesAmount;

    public CargoBuilder SetWeight(int weight)
    {
        this.weight = weight;
        return this;
    }

    public CargoBuilder SetLength(int length)
    {
        this.length = length;
        return this;
    }

    public CargoBuilder SetMaxSpeed(int maxSpeed)
    {
        this.maxSpeed = maxSpeed;
        return this;
    }

    public CargoBuilder SetTonnage(int tonnage)
    {
        this.tonnage = tonnage;
        return this;
    }

    public CargoBuilder SetTankVolume(int tankVolume)
    {
        this.tankVolume = tankVolume;
        return this;
    }

    public CargoBuilder SetAxlesAmount(int axlesAmount)
    {
        this.axlesAmount = axlesAmount;
        return this;
    }

    public Cargo Build()
    {
        return new Cargo(weight, length, maxSpeed, tonnage, tankVolume, axlesAmount);
    }
}

class TankBuilder
{
    private int weight;
    private int length;
    private int maxSpeed;
    private int caliber;
    private int shotsPerMinute;
    private int crewSize;

    public TankBuilder SetWeight(int weight)
    {
        this.weight = weight;
        return this;
    }

    public TankBuilder SetLength(int length)
    {
        this.length = length;
        return this;
    }

    public TankBuilder SetMaxSpeed(int maxSpeed)
    {
        this.maxSpeed = maxSpeed;
        return this;
    }

    public TankBuilder SetCaliber(int caliber)
    {
        this.caliber = caliber;
        return this;
    }

    public TankBuilder SetShotsPerMinute(int shotsPerMinute)
    {
        this.shotsPerMinute = shotsPerMinute;
        return this;
    }

    public TankBuilder SetCrewSize(int crewSize)
    {
        this.crewSize = crewSize;
        return this;
    }

    public Tank Build()
    {
        return new Tank(weight, length, maxSpeed, caliber, shotsPerMinute, crewSize);
    }
}

class Program
{
    private static List<Car> cars = new List<Car>();

    static void Main(string[] args)
    {
        CreateVehicle(1000, 5000, 200, "4x4", "SUV", "Red");
        CreateCargo(2000, 10000, 150, 1000, 10000, 6);
        CreateTank(3000, 20000, 300, 120, 10, 4);

        Console.WriteLine("---------");

        Vehicle customVehicle = new VehicleBuilder()
            .SetWeight(1500)
            .SetLength(4500)
            .SetMaxSpeed(250)
            .SetWheelDrive("AWD")
            .SetVehicleClass("Sedan")
            .SetColor("Blue")
            .Build();
        cars.Add(customVehicle);
        customVehicle.Display();

        Console.WriteLine("---------");

        ShowAllObjects();

        DeleteObject(1);

        ShowAllObjects();

        Console.WriteLine("---------");

        Car clonedVehicle = cars[0].Clone();
        cars[0].Display();
        clonedVehicle.MaxSpeed = 300;
        clonedVehicle.Display();
    }

    static void CreateVehicle(int weight, int length, int maxSpeed, string wheelDrive, string vehicleClass, string color)
    {
        Vehicle vehicle = new VehicleBuilder()
            .SetWeight(weight)
            .SetLength(length)
            .SetMaxSpeed(maxSpeed)
            .SetWheelDrive(wheelDrive)
            .SetVehicleClass(vehicleClass)
            .SetColor(color)
            .Build();
        cars.Add(vehicle);
        Console.WriteLine($"Vehicle: {weight}, {length}, {maxSpeed}, {wheelDrive}, {vehicleClass}, {color}");
    }

    static void CreateCargo(int weight, int length, int maxSpeed, int tonnage, int tankVolume, int axlesAmount)
    {
        Cargo cargo = new CargoBuilder()
            .SetWeight(weight)
            .SetLength(length)
            .SetMaxSpeed(maxSpeed)
            .SetTonnage(tonnage)
            .SetTankVolume(tankVolume)
            .SetAxlesAmount(axlesAmount)
            .Build();
        cars.Add(cargo);
        Console.WriteLine($"Cargo: {weight}, {length}, {maxSpeed}, {tonnage}, {tankVolume}, {axlesAmount}");
    }

    static void CreateTank(int weight, int length, int maxSpeed, int caliber, int shotsPerMinute, int crewSize)
    {
        Tank tank = new TankBuilder()
            .SetWeight(weight)
            .SetLength(length)
            .SetMaxSpeed(maxSpeed)
            .SetCaliber(caliber)
            .SetShotsPerMinute(shotsPerMinute)
            .SetCrewSize(crewSize)
            .Build();
        cars.Add(tank);
        Console.WriteLine($"Tank: {weight}, {length}, {maxSpeed}, {caliber}, {shotsPerMinute}, {crewSize}");
    }

    static void ShowAllObjects()
    {
        for (int i = 0; i < cars.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            cars[i].Display();
        }
    }

    static void DeleteObject(int index)
    {
        Car removedCar = cars[index];
        cars.RemoveAt(index);
        removedCar.Display();
    }
}
