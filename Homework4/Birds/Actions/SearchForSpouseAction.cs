namespace Coding.SOLID
{
    public class SearchForSpouseAction : IBirdAction
    {
        public bool CanHandle(IBird bird) => bird is IMateSeeker;

        public void Execute(IBird bird)
        {
            if (bird is IMateSeeker m)
            {
                m.SearchForSpause();
            }
        }
    }
}
