namespace task1.Adapter;

public static class AdapterExample
{
    public static void Execute()
    {
        LegacyService legacyService = new LegacyService();
        INewType newType = new Adapter(legacyService);
        
        Console.WriteLine("Adapter Pattern:");
        Console.WriteLine(newType.Request());
    }
}