using System;

namespace Homework3.Task1_Visitor;

public class Sphere : Shape { 
    public double Radius { get; set; } 
    public override void Accept(IVisitor visitor) => visitor.Visit(this); 
}