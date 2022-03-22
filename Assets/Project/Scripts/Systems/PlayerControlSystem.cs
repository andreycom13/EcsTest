using Leopotam.Ecs;

namespace Client
{
    internal class PlayerControlSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent> playerComponentsFilter = null;

        public void Run()
        {
            foreach (int index in playerComponentsFilter)
            {
                ref var components = ref playerComponentsFilter.Get1(index);
                components.animator.SetBool("IsRun", components.agent.velocity.magnitude > 0.1f);
                components.agent.updateRotation = true;
            }
        }
    }
}