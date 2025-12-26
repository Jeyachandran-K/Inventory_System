using JetBrains.Annotations;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position,Item item)
    {
        Transform itemWorldTransform=Instantiate(ItemAsset.Instance.GetItemWorldPrefab(), position,Quaternion.identity);
        ItemWorld itemWorld=itemWorldTransform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }

    private Item item;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        spriteRenderer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }
    public Item GetItem()
    {
        return item;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
