using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class MoveSystem : IEcsSystem, IEcsRunSystem
    {
        Player player;
        EcsFilter<MouseDownEvent> mouseEventFilter;
        EcsFilter<PlayerComponents> playerComponentsFilter;

        public void Run()
        {
            foreach (var index in mouseEventFilter)
            {
                ref var mouseEvent = ref mouseEventFilter.Get1(index);
                foreach (var playerIndex in playerComponentsFilter)
                {
                    ref var components = ref playerComponentsFilter.Get1(index);
                    components.agent.SetDestination(mouseEvent.hitPosition);
                }
            }
        }
    }
}