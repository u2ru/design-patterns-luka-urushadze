namespace task1.Facade;

public class FacadeExample
{
    public static void Execute()
    {
        Console.WriteLine("Facade Pattern:");
        
        var dvd = new DvdPlayer();
        var projector = new Projector();
        
        var homeTheater = new HomeTheaterFacade(dvd, projector);
        
        homeTheater.WatchMovie("The Matrix");
        Console.WriteLine();
        homeTheater.EndMovie();
    }
}