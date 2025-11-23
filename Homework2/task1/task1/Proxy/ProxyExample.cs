namespace task1.Proxy;

public static class ProxyExample
{
    public static void Execute()
    {
        Console.WriteLine("Proxy Pattern:");
        
        IImage image1 = new ProxyImage("photo1.jpg");
        IImage image2 = new ProxyImage("photo2.jpg");
        
        // Image will be loaded first and then displayed
        image1.Display();
        Console.WriteLine();
        
        // Will be displayed
        image1.Display();
        Console.WriteLine();
        
        // Image 2 will be loaded first and then displayed
        image2.Display();
    }
}