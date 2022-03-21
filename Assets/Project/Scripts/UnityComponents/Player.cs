using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    private void Update()
    {
        if (agent.velocity.magnitude > 0.1f) animator.SetBool("IsRun", true);
        else animator.SetBool("IsRun", false);
        agent.updateRotation = true;
    }

    public void SetMovePoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
