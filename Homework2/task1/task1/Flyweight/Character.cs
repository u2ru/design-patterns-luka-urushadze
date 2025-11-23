namespace task1.Flyweight;

public class Character : ICharacter
{
    private char symbol;
    private string font;
    private int size;

    public Character(char symbol, string font, int size)
    {
        this.symbol = symbol;
        this.font = font;
        this.size = size;
    }

    public void Display(int position)
    {
        Console.WriteLine($"Character '{symbol}' at position {position} (Font: {font}, Size: {size})");
    }
}