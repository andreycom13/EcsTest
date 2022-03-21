using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;


    private void Start()
    {
        doorAnimator.SetBool("IsOpen", false);
    }
    public void OpenDoor()
    {
        doorAnimator.SetBool("IsOpen", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenDoor();
    }
}
