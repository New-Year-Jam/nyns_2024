using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    [SerializeField] Item itemData;
    [SerializeField] Inventory inventoryToEnter;
    [SerializeField] bool canBePickedUp = true;

    // Picking up an object when close to it.
    // Need a way to tell the UI to 
    private void OnTriggerStay(Collider other) {
        if (canBePickedUp)
        {
            //TODO: Display Message

            if (Input.GetButton("Pick-Up"))
            {
                inventoryToEnter.addItem(itemData);
                Destroy(gameObject);
                Debug.Log("Item Added");
            }            
        }

    }
}
