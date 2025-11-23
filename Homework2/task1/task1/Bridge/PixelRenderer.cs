namespace task1.Bridge;

public class PixelRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Draw a PIXEL circle - radius {radius}");
    }

    public void RenderSquare(float side)
    {
        Console.WriteLine($"Draw a PIXEL square - sides {side}");
    }
}