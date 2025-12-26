
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemsList;

    public Inventory()
    {
        itemsList = new();

        AddItems(new Item() { itemType = Item.ItemType.Circle, amount = 1 });
        Debug.Log("Items List Count :"+itemsList.Count);
    }

    public void AddItems(Item item)
    {
        itemsList.Add(item);
    }

    public List<Item> GetItemsList()
    {
        return itemsList;
    }

}
