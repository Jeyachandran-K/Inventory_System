using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float playerRotateSpeed;

    private Rigidbody2D playerRigidbody2D;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            playerRigidbody2D.AddForce(transform.up * playerMovementSpeed);
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            playerRigidbody2D.AddForce(-transform.up * playerMovementSpeed);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerRigidbody2D.AddTorque(-playerRotateSpeed);
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerRigidbody2D.AddTorque(playerRotateSpeed);
        }
    }
}
