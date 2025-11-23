namespace task1.Proxy;

public class RealImage : IImage
{
    private string filename;

    public RealImage(string filename)
    {
        this.filename = filename;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine($"Loading image: {filename}");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying image: {filename}");
    }
}