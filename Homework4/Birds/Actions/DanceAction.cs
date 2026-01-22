namespace Coding.SOLID
{
    public class DanceAction : IBirdAction
    {
        public bool CanHandle(IBird bird) => bird is IDancer;

        public void Execute(IBird bird)
        {
            if (bird is IDancer d)
            {
                d.Dance();
            }
        }
    }
}
