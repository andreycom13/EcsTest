using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class InputSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;

        public void Run()
        {
            if (!Input.GetMouseButton(0))
            {
                return;
            }

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit))
            {
                return;
            }

            var entity = world.NewEntity();
            ref var mouseEvent = ref entity.Get<MouseDownEvent>();
            mouseEvent.hitPosition = hit.point;
        }
    }
}