namespace task1.Flyweight;

public class CharacterFactory
{
    private Dictionary<string, ICharacter> characters = new Dictionary<string, ICharacter>();

    public ICharacter GetCharacter(char symbol, string font, int size)
    {
        string key = $"{symbol}_{font}_{size}";
        
        if (!characters.ContainsKey(key))
        {
            characters[key] = new Character(symbol, font, size);
            Console.WriteLine($"Creating new character: {symbol}");
        }
        
        return characters[key];
    }

    public int TotalCharactersCreated => characters.Count;
}