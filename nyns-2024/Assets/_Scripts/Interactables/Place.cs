using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Place : Interactable 
{
    [Header("Place Data")]
    [SerializeField] Item itemToPlace;
    [SerializeField] Inventory inventoryToCheck;
    [SerializeField] Signal signal;
    [SerializeField] bool signalNewState;
    public override void Action()
    {
        if (inventoryToCheck.getInventory().Contains(itemToPlace))
        {
            inventoryToCheck.removeItem(itemToPlace);
            signal.changeState(signalNewState);
        }
        else
        {
            Debug.Log("You do not have the item: " + itemToPlace.name);
        }

    }
}