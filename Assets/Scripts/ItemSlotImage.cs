using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotImage : MonoBehaviour
{

    private Button imageButton;
    private Item item;
    private Vector3 itemDropOffSet;

    private void Awake()
    {
        float itemDropOffSetMultiplier = 2f;
        itemDropOffSet = Vector3.up*itemDropOffSetMultiplier;
        imageButton = GetComponent<Button>();
        imageButton.onClick.AddListener(() =>
        {
            Destroy(gameObject);
            Debug.Log("Item destroyed");
            ItemWorld.SpawnItemWorld(Player.Instance.transform.position+itemDropOffSet,item);
            GetComponentInParent<InventoryUI>().GetInventory().GetItemList().Remove(item);

        });
    }
    public Item GetItem()
    {
        return item;
    }
    public void SetItem(Item item)
    {
        this.item = item;
    }
}
