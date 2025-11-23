namespace task1.Composite;

public class Folder : IFileSystemItem
{
    private string name;
    private List<IFileSystemItem> items = new List<IFileSystemItem>();

    public Folder(string name)
    {
        this.name = name;
    }

    public void Add(IFileSystemItem item)
    {
        items.Add(item);
    }

    public void Display(string shift = "")
    {
        Console.WriteLine($"{shift}[Dir] {name}");
        foreach (var item in items)
        {
            item.Display((shift == "" ? shift : "|  ") + "|__");
        }
    }
}