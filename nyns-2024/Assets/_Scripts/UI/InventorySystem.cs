using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] Inventory inventoryToView;
    [SerializeField] InventoryListController uiList;
    [SerializeField] Signal isShowing;
    
    [Header("UI Movement Variables")]
    [SerializeField] Transform inPoint;
    [SerializeField] Transform outPoint;
    [SerializeField] float moveTime = 0.5f;
    [SerializeField] Signal cameraLock;

    [Header("Item Description Variables")]
    [SerializeField] TextMeshProUGUI headerText;
    [SerializeField] TextMeshProUGUI headerBody;
    [SerializeField] FloatingString descriptionHeader;
    [SerializeField] FloatingString descriptionBody;

    
    int previousInventorySize = 0;
    bool active = false;
    // Update is called once per frame
    void Update()
    {
        // If number of inventory items changes, tell item list panel to update the list
        if (InventoryHasChanged())
        {
            uiList.setItemListUI(inventoryToView);
            previousInventorySize = inventoryToView.getInventorySize();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            active = !active;
            cameraLock.changeState(!cameraLock.getState());
            isShowing.changeState(!isShowing.getState());
            changePosition(active);
        }

        
    }

    void changePosition(bool active)
    {
        // Change inventory position
        if (active)
        {
            LeanTween.moveX(gameObject,inPoint.position.x,moveTime).setEaseOutBounce();
        } 
        else
        {
            LeanTween.moveX(gameObject,outPoint.position.x,moveTime).setEaseInCubic();
        }
    }

    bool InventoryHasChanged() // Checks if inventory has changed in any way.

    {
        bool hasChanged = false;

        if (inventoryToView.getInventorySize() != previousInventorySize){hasChanged = true;}
        
        return hasChanged;
    }
}
