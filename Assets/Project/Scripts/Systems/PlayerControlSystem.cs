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
                if(components.agent.velocity.magnitude > 0.1f)
                {
                    components.animator.SetBool("IsRun", true);
                    components.animator.speed = components.agent.velocity.magnitude / 5f;
                }
                else
                {
                    components.animator.SetBool("IsRun", false);
                    components.animator.speed = 1;
                }
                components.agent.updateRotation = true;
            }
        }
    }
}