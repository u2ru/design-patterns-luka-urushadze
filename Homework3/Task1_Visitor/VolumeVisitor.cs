using System;

namespace Homework3.Task1_Visitor;

public class VolumeVisitor : IVisitor {
    public void Visit(Sphere s) => Console.WriteLine($"Sphere Volume: {(4.0/3.0) * Math.PI * Math.Pow(s.Radius, 3):F2}");
    public void Visit(Parallelepiped p) => Console.WriteLine($"Parallelepiped Volume: {p.Width * p.Height * p.Depth}");
    public void Visit(Torus t) => Console.WriteLine($"Torus Volume: {2 * Math.PI * Math.PI * t.MajorRadius * t.MinorRadius * t.MinorRadius:F2}");
    public void Visit(Cube c) => Console.WriteLine($"Cube Volume: {Math.Pow(c.Side, 3)}");
}
