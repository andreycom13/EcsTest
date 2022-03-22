using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Client
{
    internal class InputSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;

        private readonly EcsFilter<ClickPointViewComponent, BaseComponent> clickPointViewFilter;
        private readonly EcsFilter<PlayerComponent> playerComponentsFilter;

        public void Run()
        {
            foreach (var index in clickPointViewFilter)
            {
                ref var viewPointBase = ref clickPointViewFilter.Get2(index);
                foreach (var playerIndex in playerComponentsFilter)
                {
                    ref var player = ref playerComponentsFilter.Get1(playerIndex);
                    if (player.agent.velocity.magnitude < 0.1f)
                    {
                        viewPointBase.gameObject.SetActive(false);
                    }
                }
            }

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


            //View click point
            foreach (var index in clickPointViewFilter)
            {
                ref var viewPointBase = ref clickPointViewFilter.Get2(index);
                viewPointBase.gameObject.SetActive(true);
                viewPointBase.transform.position = hit.point;
            }
        }
    }
}