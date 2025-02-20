using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;          // Movement speed (WASD)
    public float lookSpeedX = 2f;         // Mouse look sensitivity (X axis)
    public float lookSpeedY = 2f;         // Mouse look sensitivity (Y axis)
    public Transform playerCamera;        // The player's camera
    public float gravity = -20f;          // Gravity force (controls fall speed)
    public float jumpHeight = 3.0f;       // Jump height (controls how high you jump)

    private CharacterController characterController;
    private float rotationX = 0f;         // Rotation on X (for looking up/down)
    private Vector3 velocity;             // Used for gravity and jumping

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center of the screen
        Cursor.visible = false;                   // Hide the cursor
    }

    void Update()
    {
        // Handle movement (WASD keys)
        HandleMovement();

        // Handle mouse look (camera rotation)
        HandleMouseLook();

        // Apply gravity and jumping
        HandleJumpAndGravity();
    }

    void HandleMovement()
    {
        // Get input for movement (WASD or arrow keys)
        float moveX = Input.GetAxis("Horizontal");  // A/D or Left/Right arrow
        float moveZ = Input.GetAxis("Vertical");    // W/S or Up/Down arrow

        // Create a movement vector
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply movement
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        // Get mouse input for looking around
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;

        // Rotate the player (left/right)
        transform.Rotate(Vector3.up * mouseX);

        // Adjust camera's vertical rotation (up/down)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);  // Limit vertical rotation
        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    void HandleJumpAndGravity()
    {
        // Check if the player is grounded
        if (characterController.isGrounded)
        {
            velocity.y = -2f; // A small downward force to ensure the player stays grounded

            // Handle jumping
            if (Input.GetButtonDown("Jump"))  // Jump when the player presses space
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);  // Jumping formula
            }
        }
        else
        {
            // Apply gravity when not grounded
            velocity.y += gravity * Time.deltaTime;
        }

        // Apply the vertical velocity (gravity or jump) to the character
        characterController.Move(velocity * Time.deltaTime);
    }
}
