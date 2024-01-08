using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : Interactable 
{
    [Header("PickUp Data")]
    [SerializeField] Item itemData;
    [SerializeField] Inventory inventoryToEnter;
    public override void Action()
    {
        inventoryToEnter.addItem(itemData);
        Destroy(gameObject);
        Debug.Log("Item Added");
    }
}