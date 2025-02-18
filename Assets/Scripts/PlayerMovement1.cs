using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    // Movement variables
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float crouchSpeed = 1.5f;
    private float speed;

    // Mouse look sensitivity
    public float lookSpeedX = 2.0f;
    public float lookSpeedY = 2.0f;

    // Look angle limits
    public float upperLookLimit = -60f;
    public float lowerLookLimit = 60f;

    // Other variables
    private float rotationX = 0;
    private Camera playerCamera;
    private CharacterController characterController;

    // Input keys
    public KeyCode crouchKey = KeyCode.LeftControl;
    public KeyCode sprintKey = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor in the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement and looking around
        HandleMovement();
        HandleMouseLook();
    }

    // Handles walking, running, and crouching
    void HandleMovement()
    {
        // Set the speed based on whether the player is sprinting or crouching
        if (Input.GetKey(sprintKey))
        {
            speed = runSpeed;
        }
        else if (Input.GetKey(crouchKey))
        {
            speed = crouchSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        // Get input for movement (WASD keys)
        float moveDirectionX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys
        float moveDirectionZ = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow keys

        // Movement vector
        Vector3 move = transform.right * moveDirectionX + transform.forward * moveDirectionZ;

        // Apply movement
        characterController.Move(move * speed * Time.deltaTime);
    }

    // Handles mouse look
    void HandleMouseLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate player around the Y-axis (look left and right)
        transform.Rotate(Vector3.up * mouseX * lookSpeedX);

        // Adjust camera's vertical rotation (look up and down)
        rotationX -= mouseY * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, upperLookLimit, lowerLookLimit); // Clamp to prevent full rotation
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
