namespace task1.Composite;

public class CompositeExample
{
    public static void Execute()
    {
        Console.WriteLine("Composite Pattern:");
        
        var root = new Folder("Root");
        var documents = new Folder("Documents");
        var pictures = new Folder("Pictures");
        
        documents.Add(new File("resume.pdf"));
        documents.Add(new File("report.docx"));
        
        pictures.Add(new File("vacation.jpg"));
        pictures.Add(new File("family.png"));
        
        root.Add(documents);
        root.Add(pictures);
        root.Add(new File("readme.txt"));
        
        root.Display();
    }
}