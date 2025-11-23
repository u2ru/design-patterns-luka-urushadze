namespace task1.Bridge;

public class BridgeExample
{
    public static void Execute()
    {
        Console.WriteLine("\nBridge Pattern (Shape Rendering):");
        
        IRenderer vector = new VectorRenderer();
        IRenderer raster = new PixelRenderer();

        var circle1 = new Circle(vector, 5);
        circle1.Draw();

        var circle2 = new Circle(raster, 3);
        circle2.Draw();
        circle2.Resize(2);
        circle2.Draw();
    }
}