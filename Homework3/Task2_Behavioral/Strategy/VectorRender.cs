namespace Homework3.Task2_Behavioral.Strategy;

public class VectorRender : IRenderStrategy { public void Render(string text) => Console.WriteLine($"Rendering '{text}' as Vector."); }