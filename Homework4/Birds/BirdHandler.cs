namespace Coding.SOLID
{
    internal class BirdHandler
    {
        private readonly IEnumerable<IBirdAction> _actions;
        public BirdHandler(IEnumerable<IBirdAction> actions) => _actions = actions;
        public void DoBirdAction(IBird bird)
        {
            foreach (var action in _actions)
            {
                if (action.CanHandle(bird))
                {
                    action.Execute(bird);
                }
            }
        }
    }
}
