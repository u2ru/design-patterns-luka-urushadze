namespace task1.Bridge;

public class VectorRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Draw a VECTOR circle - radius {radius}");
    }

    public void RenderSquare(float side)
    {
        Console.WriteLine($"Draw a VECTOR square - sides {side}");
    }
}