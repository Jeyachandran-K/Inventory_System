using UnityEngine;

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
        return itemType switch
        {
            ItemType.Circle => ItemAsset.Instance.circleSprite,
            ItemType.Square => ItemAsset.Instance.squareSprite,
            ItemType.Rectangle => ItemAsset.Instance.rectangleSprite,
            ItemType.Triangle => ItemAsset.Instance.triangleSprite,
            _ => null,
        };
    }
}
