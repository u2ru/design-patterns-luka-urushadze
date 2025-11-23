namespace task1.Proxy;

public class ProxyImage : IImage
{
    private string filename;
    private RealImage realImage;

    public ProxyImage(string filename)
    {
        this.filename = filename;
    }

    public void Display()
    {
        if (realImage == null)
        {
            realImage = new RealImage(filename);
        }
        realImage.Display();
    }
}