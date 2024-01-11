using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class Interactable : MonoBehaviour
{
    [Header("Interactable Info")]
    [SerializeField] string interactionName;
    [SerializeField] bool active;    
    public abstract void Action();

    // private void OnTriggerStay(Collider other) {
    //     if (active) //TODO: Make it so it checks if the player is actually looking at the interactable too.
    //     {
    //         //TODO: Display Message


    //         if (Input.GetButton("Interact"))
    //         {
    //             Action();
    //         }            
    //     }
    // }
}
