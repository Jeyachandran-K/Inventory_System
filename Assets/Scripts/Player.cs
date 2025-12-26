using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event EventHandler OnHittingItems;

    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float playerRotateSpeed;
    [SerializeField] private InventoryUI inventoryUI;

    private Rigidbody2D playerRigidbody2D;
    private Inventory inventory;

    private void Awake()
    {
        Instance = this;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        inventory = new Inventory();
        
    }
    private void Start()
    {
        inventoryUI.SetInventory(inventory);
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
            bool itemAlreadyExist=false;

            if (itemWorld.GetItem().GetIsStackable())
            {
                if (inventory.GetItemList().Count == 0)
                {
                    inventory.AddItem(itemWorld.GetItem());
                    itemAlreadyExist = true;
                    itemWorld.DestroySelf();
                }
                else
                {
                    foreach (Item item in inventory.GetItemList())
                    {
                        if (item.itemType == itemWorld.GetItem().itemType)
                        {
                            item.amount += itemWorld.GetItem().amount;
                            itemAlreadyExist = true;
                            itemWorld.DestroySelf();
                            break;
                        }
                    }
                }
            }
            else
            {
                if (inventory.IsFull())
                {
                    Debug.Log("Inventory is full");
                }
                else
                {
                    inventory.AddItem(itemWorld.GetItem());
                    itemAlreadyExist = true;
                    itemWorld.DestroySelf();
                }
                
            }
            if (!itemAlreadyExist)
            {
                if (inventory.IsFull())
                {
                    Debug.Log("Inventory is full");
                }
                else
                {
                    inventory.AddItem(itemWorld.GetItem());
                    itemWorld.DestroySelf();
                }
                   
            }
            OnHittingItems?.Invoke(this, EventArgs.Empty);
            
        }
    }
}
