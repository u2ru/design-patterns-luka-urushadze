namespace design_patterns_luka_urushadze.Homework1;

public class PrototypeExample
{
    private string Name { get; set; }

    public PrototypeExample(string name)
    {
        Name = name;
    }

    public PrototypeExample Clone()
    {
        return new PrototypeExample(this.Name);
    }
}