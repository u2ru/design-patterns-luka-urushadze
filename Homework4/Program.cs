using Coding.SOLID;

var handler = new BirdHandler(new List<IBirdAction>
{
    new FlyAction(),
    new WalkAction(),
    new SingAction(),
    new DefendEggAction(),
    new DanceAction(),
    new SearchForSpouseAction(),
    new ProduceEggAction()
});
var birdFactory = new BirdProducer();
var birds = new List<IBird>
{
    birdFactory.Create("Pinguin"),
    birdFactory.Create("Sparrow"),
};

foreach (var bird in birds)
{
    Console.WriteLine($"--- {bird.GetType().Name} ---");
    handler.DoBirdAction(bird);
    Console.WriteLine();
}
