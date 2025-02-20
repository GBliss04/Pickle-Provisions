using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro

public class PressurePlateTakeMoney : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // Reference to the UI Text element
    public int moneyAmountRequired = 0; // The amount of money required to activate the plate
    public int moneyAmountToTake = -50; // Amount of money to deduct when the plate is triggered
    private int totalMoney = 0; // Initial total money (can be linked to a player system)
    
    public GameObject wallPrefab; // Reference to the wall prefab
    public Transform wallSpawnPosition; // Position where the wall will spawn (can be set in the inspector)
    
    public GameObject anotherPrefab; // Reference to the new additional prefab (can be anything you want)
    public Transform anotherPrefabSpawnPosition; // Position where the new prefab will spawn (can be set in the inspector)

    private void Start()
    {
        // Update the money display at the start
        UpdateMoneyDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player stepped on the pressure plate
        if (other.CompareTag("Player"))
        {
            // Check if the player has enough money
            if (totalMoney >= moneyAmountRequired)
            {
                // Deduct money and update UI
                DeductMoney();

                // Summon the wall after purchasing
                SummonWall();

                // Summon the other prefab (can be any object, like a key, door, etc.)
                SummonAnotherPrefab();

                // Disable the pressure plate (make it disappear)
                DisablePressurePlate();
            }
            else
            {
                // Optional: Inform the player that they don't have enough money
                Debug.Log("Not enough money to activate the pressure plate.");
            }
        }
    }

    private void DeductMoney()
    {
        // Subtract the specified amount of money from the player's total
        totalMoney -= moneyAmountToTake;

        // Update the UI with the new money value
        UpdateMoneyDisplay();
    }

    private void SummonWall()
    {
        // Instantiate the wall prefab at the designated spawn position
        if (wallPrefab != null && wallSpawnPosition != null)
        {
            Instantiate(wallPrefab, wallSpawnPosition.position, wallSpawnPosition.rotation);
        }
        else
        {
            Debug.LogWarning("Wall prefab or spawn position is not set.");
        }
    }

    private void SummonAnotherPrefab()
    {
        // Instantiate the additional prefab at the designated spawn position
        if (anotherPrefab != null && anotherPrefabSpawnPosition != null)
        {
            Instantiate(anotherPrefab, anotherPrefabSpawnPosition.position, anotherPrefabSpawnPosition.rotation);
        }
        else
        {
            Debug.LogWarning("Additional prefab or spawn position is not set.");
        }
    }

    private void DisablePressurePlate()
    {
        // Disable the pressure plate's collider so it can't be triggered again
        Collider plateCollider = GetComponent<Collider>();
        if (plateCollider != null)
        {
            plateCollider.enabled = false; // Disables the collider (can be re-enabled later if needed)
        }

        // Optionally, hide or disable the pressure plate object completely
        gameObject.SetActive(false); // Disables the entire object (can be re-enabled if needed).
    }

    private void UpdateMoneyDisplay()
    {
        // Update the TextMeshPro UI to show the current money value
        moneyText.text = "Money: $" + totalMoney.ToString();
    }
}
