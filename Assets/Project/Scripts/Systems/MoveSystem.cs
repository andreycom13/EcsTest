using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class MoveSystem : IEcsSystem, IEcsRunSystem
    {
        Player player;
        EcsFilter<MouseDownEvent> mouseEventFilter;

        public void Run()
        {
            foreach (var index in mouseEventFilter)
            {
                ref var mouseEvent = ref mouseEventFilter.Get1(index);
                player.SetMovePoint(mouseEvent.hitPosition);
            }
        }
    }
}