using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;          // Movement speed
    public float lookSpeedX = 2f;         // Mouse look sensitivity (X axis)
    public float lookSpeedY = 2f;         // Mouse look sensitivity (Y axis)
    public Transform playerCamera;        // The player's camera
    public float gravity = -9.8f;         // Gravity

    private CharacterController characterController;
    private float rotationX = 0f;         // Rotation on X (for looking up/down)

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center of the screen
        Cursor.visible = false;                   // Make the cursor invisible
    }

    void Update()
    {
        // Handle movement
        float moveX = Input.GetAxis("Horizontal");  // A/D or Left/Right arrow
        float moveZ = Input.GetAxis("Vertical");    // W/S or Up/Down arrow

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Handle camera rotation
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;

        rotationX -= mouseY; // Look up and down
        rotationX = Mathf.Clamp(rotationX, -80f, 80f); // Limit vertical rotation

        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Rotate camera (up/down)
        transform.Rotate(Vector3.up * mouseX); // Rotate player (left/right)

        // Apply gravity
        if (characterController.isGrounded)
        {
            Vector3 velocity = new Vector3(0, gravity, 0);  // Apply gravity only when grounded
            characterController.Move(velocity * Time.deltaTime);
        }
        else
        {
            Vector3 velocity = new Vector3(0, gravity, 0);
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}

