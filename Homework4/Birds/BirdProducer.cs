namespace Coding.SOLID
{
    public class BirdProducer : IBirdFactory
    {
        public IBird Create(string type)
        {
            return type switch
            {
                "Pinguin" => new Pinguin(),
                "Sparrow" => new Sparrow(),
                _ => throw new ArgumentException($"Unknown type: {type}"),
            };
        }
    }
}
