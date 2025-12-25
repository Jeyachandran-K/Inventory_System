using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Circle,
        Triangle,
        Square,
    }
    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            case ItemType.Circle: return ItemAsset.Instance.GetCircleSprite();
            case ItemType.Square: return ItemAsset.Instance.GetSquareSprite();
            case ItemType.Triangle: return ItemAsset.Instance.GetRectangleSprite();
        }
        return null;
    }

}
