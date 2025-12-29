public abstract class Car {
    private string _model;

    public event Action<Car, string, string, string>? PropertyChanged;

    public string Model {
        get => _model;
        set {
            if (_model == value) return;
            string old = _model;
            _model = value;
            PropertyChanged?.Invoke(this, nameof(Model), old, value);
        }
    }
}