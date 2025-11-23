namespace task1.Adapter;

public class Adapter : INewType
{
    private readonly LegacyService _adaptee;

    public Adapter(LegacyService adaptee)
    {
        _adaptee = adaptee;
    }

    public string Request()
    {
        return $"This is '{_adaptee.OldRequest()}'";
    }
}