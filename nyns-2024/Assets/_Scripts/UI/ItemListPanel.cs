using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

// Controls the item list panel. Giving it the info to set up its name 
// (and potentially button effects if we want that)
public class ItemListPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Item itemData;
    [SerializeField] TextMeshProUGUI uiName;
    [SerializeField] FloatingString descriptionHeader;
    [SerializeField] FloatingString descriptionBody;
    public void SetItemData(Item item){itemData = item; SetUI();}
    void SetUI(){uiName.text = itemData.name;}
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
        descriptionHeader.changeString(itemData.getName());
        descriptionBody.changeString(itemData.getDescription());
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
        descriptionHeader.changeString("");
        descriptionBody.changeString("");
    }


}
