using System.Collections;
using System.Collections.Generic;
// using UnityEditorInternal.VersionControl;
using UnityEngine;

// Controls the ItemListPanel and sets the list items.
public class InventoryListController : MonoBehaviour
{

    [SerializeField] GameObject listUIObject;

    public void setItemListUI(Inventory inventory)
    {
        clearInventoryUI();

        List<Item> itemList = inventory.getInventory();
        for (int i = 0; i < itemList.Count; i++)
        {
            GameObject listItem = Instantiate(listUIObject);
            listItem.name = itemList[i].name + " - UI";
            listItem.GetComponent<ItemListPanel>().SetItemData(itemList[i]);
            listItem.transform.SetParent(this.transform);
        }
    }

    private void clearInventoryUI()
    {
        int childCount = this.transform.childCount;

        for (int i = 1; i < childCount; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;
            Destroy(childObject);
        }
    }
}
