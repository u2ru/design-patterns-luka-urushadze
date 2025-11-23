namespace task1.Facade;

public class HomeTheaterFacade
{
    private DvdPlayer dvd;
    private Projector projector;

    public HomeTheaterFacade(DvdPlayer dvd, Projector projector)
    {
        this.dvd = dvd;
        this.projector = projector;
    }

    public void WatchMovie(string movie)
    {
        Console.WriteLine("Get ready to watch a movie...");
        projector.On();
        projector.SetInput("DVD");
        dvd.On();
        dvd.Play(movie);
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting down the home theater...");
        dvd.Off();
        projector.Off();
    }
}