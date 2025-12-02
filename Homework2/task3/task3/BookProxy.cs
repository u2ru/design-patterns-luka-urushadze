namespace task3;

public class BookProxy : IBook
{
    private readonly int _id;
    private readonly string _title;
    private RealBook _realBook;
    private bool _isLoaded = false;

    public BookProxy(int id, string title)
    {
        _id = id;
        _title = title;
        Console.WriteLine($"Proxy fro book '{title}'");
    }

    public int Id => _id;
    public string Title => _title;
    public string Content => _isLoaded ? _realBook.Content : "Book not loaded";

    public string Read(User user)
    {
        if (!user.IsRegistered)
            return $"error: user {user.Name} not registered";

        if (!user.HasAccess)
            return $"error: user {user.Name} cant access the book";

        if (!_isLoaded)
        {
            _realBook = new RealBook(_id, _title);
            _isLoaded = true;
        }
        
        return _realBook.Read(user);
    }
}