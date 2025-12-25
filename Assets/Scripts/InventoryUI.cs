using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;

    [SerializeField]private Transform itemSlotImage;

    private void Awake()
    {
        itemSlotContainer = GetComponentInChildren<ItemSlotContainer>().gameObject.transform;

    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventory();
    }
    private void RefreshInventory()
    {
        int x = 0;
        int y = 0;
        int cellSize = 100;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotImageRecttransform = Instantiate(itemSlotImage, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotImageRecttransform.anchoredPosition = new Vector2(x*cellSize,y*cellSize);
            itemSlotImageRecttransform.gameObject.GetComponent<Image>().sprite = item.GetSprite();
            x++;
            if (x > 4)
            {
                x = 0;
                y--;
            }
        }
    }
}
