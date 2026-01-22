namespace Coding.SOLID
{
    public class ProduceEggAction : IBirdAction
    {
        public bool CanHandle(IBird bird) => bird is IEggLayer;

        public void Execute(IBird bird)
        {
            if (bird is IEggLayer e)
            {
                e.ProduceEgg();
            }
        }
    }
}
