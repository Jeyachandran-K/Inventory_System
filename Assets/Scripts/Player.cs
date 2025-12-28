using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event EventHandler OnHittingItems;

    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float playerRotateSpeed;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private ToolbarUI toolbarUI;

    private Rigidbody2D playerRigidbody2D;
    private Inventory inventory;
    private Inventory toolBarInventory;

    private void Awake()
    {
        Instance = this;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        inventory = new Inventory(15);
        toolBarInventory = new Inventory(14);
        
    }
    private void Start()
    {
        inventoryUI.SetInventory(inventory);
        toolbarUI.SetInventory(toolBarInventory);
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            playerRigidbody2D.AddForce(Vector3.up * playerMovementSpeed);
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            playerRigidbody2D.AddForce(Vector3.down * playerMovementSpeed);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerRigidbody2D.AddForce(Vector3.right * playerMovementSpeed);
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerRigidbody2D.AddForce(Vector3.left * playerMovementSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.TryGetComponent<ItemWorld>(out ItemWorld itemWorld))
        {
            Inventory inventoryTemp = toolBarInventory.IsFull()? inventory : toolBarInventory;
            LogicCheck(itemWorld,inventoryTemp);
            OnHittingItems?.Invoke(this, EventArgs.Empty);

        }
    }

    private void LogicCheck(ItemWorld itemWorld, Inventory inventoryTemp)
    {
        bool itemAlreadyExist = false;

        if (itemWorld.GetItem().GetIsStackable())
        {
            if (inventoryTemp.GetItemList().Count == 0)
            {
                inventoryTemp.AddItem(itemWorld.GetItem());
                itemAlreadyExist = true;
                itemWorld.DestroySelf();
            }
            else
            {
                itemAlreadyExist = CheckItemExist(itemWorld, itemAlreadyExist, inventoryTemp);
            }
        }
        else
        {
            AddItemToInventory(itemWorld, inventoryTemp);
            itemAlreadyExist = true;

        }
        if (!itemAlreadyExist)
        {
            AddItemToInventory(itemWorld, inventoryTemp);
        }
    }

    private bool CheckItemExist(ItemWorld itemWorld, bool itemAlreadyExist, Inventory inventoryTemp)
    {
        foreach (Item item in inventoryTemp.GetItemList())
        {
            if (item.itemType == itemWorld.GetItem().itemType)
            {
                if(item.amount== inventoryTemp.GetMaxStackableNumber()) continue;
                int itemSum = ItemSum(item, itemWorld);
                if(itemSum > inventoryTemp.GetMaxStackableNumber())
                {
                    int storableItem = inventoryTemp.GetMaxStackableNumber() - item.amount;
                    item.amount += storableItem;
                    itemWorld.GetItem().amount -= storableItem;
                    itemWorld.RefreshAmount();
                    AddItemToInventory(itemWorld, inventoryTemp);
                    itemAlreadyExist = true;
                    break;
                }
                else
                {
                    item.amount += itemWorld.GetItem().amount;
                    itemAlreadyExist = true;
                    itemWorld.DestroySelf();
                    break;
                }
                
            }
        }

        return itemAlreadyExist;
    }

    private void AddItemToInventory(ItemWorld itemWorld, Inventory inventoryTemp)
    {
        if (inventoryTemp.IsFull())
        {
            Debug.Log("Inventory is full");
        }
        else
        {
            inventoryTemp.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    private int ItemSum(Item item,ItemWorld itemWorld)
    {
        return item.amount + itemWorld.GetItem().amount;
    }
}
