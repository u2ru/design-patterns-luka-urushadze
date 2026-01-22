namespace Coding.SOLID;

public class SingAction : IBirdAction
{
    public bool CanHandle(IBird bird) => bird is ISinger;

    public void Execute(IBird bird)
    {
        if (bird is ISinger s)
        {
            s.Sing();
        }
    }
}
