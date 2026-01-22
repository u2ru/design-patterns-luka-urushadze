namespace Coding.SOLID
{
    internal class Pinguin : IDancer, ISinger, IMateSeeker, IEggLayer, IWalker, IBird
    {
        public string Name { get; }

        public Pinguin(string name = "Pinguin") => Name = name;

        public void DefendEgg()
        {
            Console.WriteLine("Hit the enemy");
        }

        public void Dance()
        {
            Console.WriteLine("Shake your body");
        }

        public void ProduceEgg()
        {
            Console.WriteLine("Some magic happens");
        }

        public void SearchForSpause()
        {
            Console.WriteLine("Time to search for the spause");
            this.Sing();
        }

        public void Sing()
        {
            Console.WriteLine("Some Iron Maiden song from 80-th");
        }

        public void Walk()
        {
            Console.WriteLine("Walk this way");
        }
    }
}
