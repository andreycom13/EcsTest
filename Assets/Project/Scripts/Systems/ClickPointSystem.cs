using Leopotam.Ecs;

namespace Client
{
    internal class ClickPointSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MouseDownEvent> mouseDownEventFilter = null;
        private readonly EcsFilter<ClickPointComponent, BaseComponent> clickPointFilter = null;

        public void Run()
        {
            if (mouseDownEventFilter.IsEmpty() || clickPointFilter.IsEmpty())
            {
                return;
            }

            ref var mouseDownEvent = ref mouseDownEventFilter.Get1(0);
            ref var clickPoint = ref clickPointFilter.Get2(0);
            clickPoint.transform.position = mouseDownEvent.hitPosition;
        }
    }
}