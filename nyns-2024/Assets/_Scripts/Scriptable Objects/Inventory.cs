using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "nyns-2024/Inventory", order = 0)]
public class Inventory : ScriptableObject {
    [SerializeField] List<Item> startingItems;
    List<Item> itemList;


    public void addItem(Item item) 
    {
        if (itemList.Contains(item))
        {
            Console.WriteLine("cannot add item: Item already in inventory");
        } 
        else
        {
            itemList.Add(item);
        }
    }
    public void removeItem(Item item) 
    {
        if (itemList.Contains(item))
        {
            itemList.Remove(item);
        }
        else
        {
            Console.WriteLine("cannot remove item: Item is not in inventory to begin with");
        }
    }

    public List<Item> getInventory(){return itemList;}

    public int getInventorySize(){return itemList.Count;}

    public void OnEnable() {
        itemList = new List<Item>(startingItems);
    }
}