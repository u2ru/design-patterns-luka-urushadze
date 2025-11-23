namespace task1.Composite;

public class File : IFileSystemItem
{
    private string name;

    public File(string name)
    {
        this.name = name;
    }

    public void Display(string shift = "")
    {
        Console.WriteLine($"{shift}[File] {name}");
    }
}