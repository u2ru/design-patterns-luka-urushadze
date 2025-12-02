namespace task3;

public class RealBook : IBook
{
    public int Id { get; }
    public string Title { get; }
    public string Content { get; set; }

    public RealBook(int id, string title)
    {
        Id = id;
        Title = title;
        
        Console.WriteLine($"Loading book: '{title}'");
        Thread.Sleep(2000);
        
        Content = $"===== '{title}' =======\n" +
                  "Page 1: ...\n" +
                  "page 2: ...\n" +
                  "page 3: ...";
        
        Console.WriteLine($"Book: '{title}' Loaded!");
    }

    public string Read(User user)
    {
        return $"User {user.Name} is reading book '{Title}':\n{Content}";
    }
}