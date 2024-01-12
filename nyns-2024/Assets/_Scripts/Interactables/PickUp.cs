using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : Interactable 
{
    [Header("PickUp Data")]
    [SerializeField] Item itemData;
    [SerializeField] Inventory inventoryToEnter;
    [SerializeField] DialogueSystem _dialogueSystem;
    [SerializeField] Dialogue _dialogue;

    public override void Action()
    {
        inventoryToEnter.addItem(itemData);
        Destroy(gameObject);
        Debug.Log("Item Added");

        if (_dialogue != null)
        {
            _dialogueSystem.gameObject.SetActive(true);
            _dialogueSystem.SetDialogue(_dialogue.getLines());
        }
    }
}