using Client;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

public class PlayerActor : Actor
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    public override void ExpandEntity()
    {
        ref var playerComponents = ref entity.Get<PlayerComponent>();
        playerComponents.agent = agent;
        playerComponents.animator = animator;
    }
}