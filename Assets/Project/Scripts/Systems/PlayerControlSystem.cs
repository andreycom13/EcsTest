using Leopotam.Ecs;

namespace Client
{
    internal class PlayerControlSystem : IEcsSystem, IEcsInitSystem, IEcsRunSystem
    {
        EcsWorld world;
        Player player;

        EcsFilter<PlayerComponents> playerComponentsFilter;

        public void Init()
        {
            EcsEntity entity = world.NewEntity();
            ref var playerComponents = ref entity.Get<PlayerComponents>();
            playerComponents.agent = player.GetNavMeshAgent;
            playerComponents.animator = player.GetAnimator;
        }

        public void Run()
        {
            foreach (var index in playerComponentsFilter)
            {
                ref var components = ref playerComponentsFilter.Get1(index);
                if (components.agent.velocity.magnitude > 0.1f) components.animator.SetBool("IsRun", true);
                else components.animator.SetBool("IsRun", false);
                components.agent.updateRotation = true;
            }
        }
    }
}