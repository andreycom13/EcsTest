using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class InputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private Camera camera;

        public void Init()
        {
            camera = Camera.main;
        }

        public void Run()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit))
            {
                return;
            }
            world.NewEntity().Get<MouseDownEvent>().hitPosition = hit.point;
        }
    }
}