using System;

namespace Homework3.Task1_Visitor;

public class Parallelepiped : Shape { 
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public override void Accept(IVisitor visitor) => visitor.Visit(this); 
}