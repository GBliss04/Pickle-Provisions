using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyObject : MonoBehaviour
{
    public int moneyValue = 10; // Initial value of money
    private Rigidbody rb;
    public float conveyorSpeed = 3f; // Conveyor speed
    private bool isOnConveyor = false; // Whether the object is on the conveyor

    private bool hasUpgraded = false; // Track whether the upgrade has happened

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Apply a small random torque (rotational force) to make it fall naturally when spawned
        Vector3 randomTorque = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }

    private void Update()
    {
        // If the object is on the conveyor, move it along the conveyor's direction
        if (isOnConveyor)
        {
            // Apply movement along the conveyor (forward along Z-axis)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, conveyorSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the money object enters the "UpgradeDoor" trigger and if it hasn't upgraded yet
        if (other.CompareTag("UpgradeDoor") && !hasUpgraded)
        {
            // Double the money value when passing through the upgrade door
            moneyValue *= 2;
            // Debug.Log("Money upgraded! New value: " + moneyValue);

            // Mark the money object as upgraded
            hasUpgraded = true;
        }

        // Check if the money object enters the "Collector" trigger
        if (other.CompareTag("Collector")) // Check if the collector picks it up
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // Find the player in the scene
            if (player != null)
            {
                PlayerMoney playerMoney = player.GetComponent<PlayerMoney>();
                if (playerMoney != null)
                {
                    playerMoney.AddMoney(moneyValue); // Add the upgraded money to the player
                }
            }

            Destroy(gameObject); // Remove the money object after collection
        }

        // If the money enters the conveyor zone, we want it to start moving
        if (other.CompareTag("Conveyor"))
        {
            isOnConveyor = true; // Start moving with the conveyor
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Stop movement when exiting the conveyor zone
        if (other.CompareTag("Conveyor"))
        {
            isOnConveyor = false; // Stop moving with the conveyor
            rb.velocity = Vector3.zero; // Stop any existing movement
        }
    }
}
