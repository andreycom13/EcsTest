using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class InputSystem : IEcsSystem, IEcsRunSystem
    {
        EcsWorld world;
        public void Run()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    EcsEntity entity = world.NewEntity();
                    ref var mouseEvent = ref entity.Get<MouseDownEvent>();
                    mouseEvent.hitPosition = hit.point;
                }
            }
        }
    }
}