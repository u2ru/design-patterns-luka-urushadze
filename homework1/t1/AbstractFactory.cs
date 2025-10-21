namespace design_patterns_luka_urushadze.Homework1;

public interface IButton
{
    string Render();
}

public class IOSButton : IButton
{
    public string Render()
    {
        return "IOS-style button.";
    }
}

public class AndroidButton : IButton
{
    public string Render()
    {
        return "Android-style button.";
    }
}

public interface IUIFactory
{
    IButton CreateButton();
}

public class IOSFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new IOSButton();
    }
}

public class AndroidFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new AndroidButton();
    }
}

public class Abstr
{
    private readonly IButton _button;
    
    public Abstr(IUIFactory factory)
    {
        _button = factory.CreateButton();
    }
    
    public void Run()
    {
        Console.WriteLine(_button.Render());
    }
}