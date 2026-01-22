namespace Coding.SOLID
{
    public class DefendEggAction : IBirdAction
    {
        public bool CanHandle(IBird bird) => bird is IEggLayer;

        public void Execute(IBird bird)
        {
            if (bird is IEggLayer e)
            {
                e.DefendEgg();
            }
        }
    }
}
