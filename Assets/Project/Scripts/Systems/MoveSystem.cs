using Leopotam.Ecs;

namespace Client
{
    internal class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MouseDownEvent> mouseEventFilter = null;
        private readonly EcsFilter<PlayerComponent> playerComponentsFilter = null;

        public void Run()
        {
            foreach (int index in mouseEventFilter)
            {
                ref var mouseEvent = ref mouseEventFilter.Get1(index);
                foreach (int playerIndex in playerComponentsFilter)
                {
                    ref var components = ref playerComponentsFilter.Get1(index);
                    components.agent.SetDestination(mouseEvent.hitPosition);
                }
            }
        }
    }
}