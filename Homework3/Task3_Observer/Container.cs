public class Container {
    private readonly List<Car> _cars = new();

    public void Add(Car car) {
        _cars.Add(car);
        Console.WriteLine($"[Collection]: Added new {car.GetType().Name}");
        car.PropertyChanged += HandlePropertyChange;
    }

    private void HandlePropertyChange(Car car, string prop, string oldVal, string newVal) {
        Console.WriteLine($"[Observer]: {car.GetType().Name} updated! Property '{prop}' changed from '{oldVal}' to '{newVal}'");
    }
}