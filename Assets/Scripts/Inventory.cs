
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;
    private readonly int maxItemSlot = 15;
    private readonly int maxStackableNumber = 10;
    private bool isFull;

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
        isFull = itemList.Count >= maxItemSlot;
        return isFull;
    }
    public  int GetMaxStackableNumber()
    {
        return maxStackableNumber;
    }

}
