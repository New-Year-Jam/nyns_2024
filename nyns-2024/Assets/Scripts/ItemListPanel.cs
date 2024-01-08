using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

// Controls the item list panel. Giving it the info to set up its name 
// (and potentially button effects if we want that)
public class ItemListPanel : MonoBehaviour
{
    Item itemData;
    [SerializeField] TextMeshProUGUI uiName;
    public void SetItemData(Item item){itemData = item; SetUI();}
    void SetUI(){uiName.text = itemData.name;}
}
