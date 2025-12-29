using Homework3.Task1_Visitor;

public class Cube : Shape { 
    public double Side { get; set; } 
    public override void Accept(IVisitor visitor) => visitor.Visit(this); 
}