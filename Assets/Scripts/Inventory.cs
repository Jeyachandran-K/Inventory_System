
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;
    private int maxItemSlot = 15;
    private int maxStackableNumber = 10;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
    public bool IsFull()
    {
        return itemList.Count >= maxItemSlot;
    }
    public  int GetMaxStackableNumber()
    {
        return maxStackableNumber;
    }

}
