namespace Homework3.Task1_Visitor;
public interface IVisitor {
    void Visit(Sphere sphere);
    void Visit(Parallelepiped p);
    void Visit(Torus torus);
    void Visit(Cube cube);
}