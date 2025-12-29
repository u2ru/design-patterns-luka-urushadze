namespace Homework3.Task2_Behavioral.Command;

public class PrintCommand : ICommand
{
    private string _content;

    public PrintCommand(string content)
    {
        _content = content;
    }

    public void Execute()
    {
        Console.WriteLine($"[Command]: Printing content -> {_content}");
    }
}