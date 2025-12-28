using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarUI : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private int maxItemSlot = 14;

    [SerializeField] private Transform itemSlotImage;

    private void Awake()
    {
        itemSlotContainer = GetComponentInChildren<ItemSlotContainer>().gameObject.transform;
    }
    private void Start()
    {
        Player.Instance.OnHittingItems += Player_OnHittingItems;
    }
    private void Player_OnHittingItems(object sender, System.EventArgs e)
    {
        RefreshInventory();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventory();
    }
    public Inventory GetInventory()
    {
        return inventory;
    }
    private void RefreshInventory()
    {
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        int cellSize = 100;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotImageRecttransform = Instantiate(itemSlotImage, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotImageRecttransform.anchoredPosition = new Vector2(x * cellSize, y * cellSize);
            itemSlotImageRecttransform.gameObject.GetComponent<Image>().sprite = item.GetSprite();
            itemSlotImageRecttransform.gameObject.GetComponent<ItemSlotImage>().SetItem(item);
            if (item.amount > 1)
            {
                itemSlotImageRecttransform.GetComponentInChildren<TextMeshProUGUI>().text = item.amount.ToString();
            }
            x++;
            if (x > 13)
            {
                x = 0;
            }
        }
    }
}
