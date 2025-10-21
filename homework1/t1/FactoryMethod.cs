namespace design_patterns_luka_urushadze.Homework1;

public class BikeFactory
{
    private string Model { get; set; }
    public ColorClass Paint { get; set; }
    
    public BikeFactory(string model, string color)
    {
        Model = model;
        Paint = new PaintFactory(color).Paint();
    }
}

public class CarFactory 
{
    private string Model { get; set; }
    public ColorClass Paint { get; set; }
    
    public CarFactory(string model, string color)
    {
        Model = model;
        Paint = new PaintFactory(color).Paint();
    }
}

public class ColorClass
{
    private string Name { get; set; }
    
    public ColorClass(string name)
    {
        Name = name;
    }
}

public class PaintFactory
{
    private string Color { get; set; }
    
    public PaintFactory(string color)
    {
        Color = color;
    }

    public ColorClass Paint()
    {
        return new ColorClass(Color);
    }
}