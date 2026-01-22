namespace Coding.SOLID;

public interface IBirdAction
{
    bool CanHandle(IBird bird);
    void Execute(IBird bird);
}