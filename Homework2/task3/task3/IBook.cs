namespace task3;

public interface IBook
{
    int Id { get; }
    string Title { get; }
    string Content { get; }
    string Read(User user);
}