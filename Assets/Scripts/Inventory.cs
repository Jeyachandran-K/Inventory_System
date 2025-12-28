
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;
    private int maxItemSlot;
    private int maxStackableNumber = 10;

    public Inventory(int maxItemSlot)
    {
        itemList = new List<Item>();
        this.maxItemSlot = maxItemSlot;
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
