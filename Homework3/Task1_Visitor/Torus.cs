using System;

namespace Homework3.Task1_Visitor;

public class Torus : Shape { 
    public double MajorRadius { get; set; }
    public double MinorRadius { get; set; }
    public override void Accept(IVisitor visitor) => visitor.Visit(this); 
}