namespace Coding.SOLID;

public class FlyAction: IBirdAction
{
    public bool CanHandle(IBird bird) => bird is IFlyable;
    public void Execute(IBird bird)
    {
        if (bird is IFlyable f) f.Fly();
    }
}