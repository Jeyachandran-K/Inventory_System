using System;
using UnityEngine;

[Serializable]
public class Item 
{
    public enum ItemType
    {
        Circle,
        Rectangle,
        Square,
        Triangle
    }
    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            case ItemType.Circle: return ItemAsset.Instance.GetCircleSprite();
            case ItemType.Square: return ItemAsset.Instance.GetSquareSprite();
            case ItemType.Rectangle: return ItemAsset.Instance.GetRectangleSprite();
            case ItemType.Triangle: return ItemAsset.Instance.GetTriangleSprite();  
        }
        return null;
    }
    public bool GetIsStackable()
    {
        switch (itemType)
        {
            case ItemType.Circle:
            case ItemType.Square:
                return true;
            case ItemType.Rectangle:
            case ItemType.Triangle:
                return false;
            default: 
                return false;
        }
    }

}
