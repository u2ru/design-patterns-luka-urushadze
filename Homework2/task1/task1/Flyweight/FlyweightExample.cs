namespace task1.Flyweight;

public class FlyweightExample
{
    public static void Execute()
    {
        Console.WriteLine("Flyweight Pattern:");
        
        var factory = new CharacterFactory();
        
        string text = "HELLO";
        int position = 0;
        
        foreach (char c in text)
        {
            var character = factory.GetCharacter(c, "Sans-Serif", 12);
            character.Display(position++);
        }
        
        Console.WriteLine($"\nTotal unique characters: {factory.TotalCharactersCreated}");
    }
}