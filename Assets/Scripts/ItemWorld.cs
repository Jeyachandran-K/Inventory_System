using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private TextMeshPro worldTextMesh;
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
        worldTextMesh = GetComponentInChildren<TextMeshPro>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        spriteRenderer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        if (item.amount > 1)
        {
            worldTextMesh.text = item.amount.ToString();
        }
        else
        {
            worldTextMesh.text = "";
        }
        

    }
    public Item GetItem()
    {
        return item;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public void RefreshAmount()
    {
        worldTextMesh.text = item.amount.ToString();
    }
}
