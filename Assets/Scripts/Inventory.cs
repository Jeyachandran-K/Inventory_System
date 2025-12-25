
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item() { itemType = Item.ItemType.Triangle, amount = 1 });
        AddItem(new Item() { itemType=Item.ItemType.Circle, amount =1});
        AddItem(new Item() { itemType=Item.ItemType.Square, amount =1});
        AddItem(new Item() { itemType = Item.ItemType.Triangle, amount = 1 });
        AddItem(new Item() { itemType = Item.ItemType.Circle, amount = 1 });
        AddItem(new Item() { itemType = Item.ItemType.Square, amount = 1 });

        Debug.Log(itemList.Count);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
    private void AddItem(Item item)
    {
        itemList.Add(item);
    }
}
