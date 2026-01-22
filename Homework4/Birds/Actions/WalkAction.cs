namespace Coding.SOLID
{
    public class WalkAction : IBirdAction
    {
        public bool CanHandle(IBird bird) => bird is IWalker;

        public void Execute(IBird bird)
        {
            if (bird is IWalker w)
            {
                w.Walk();
            }
        }
    }
}
