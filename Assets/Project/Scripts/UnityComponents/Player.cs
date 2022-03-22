using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    public NavMeshAgent GetNavMeshAgent { get { return agent; } }
    public Animator GetAnimator { get { return animator; } }
}
