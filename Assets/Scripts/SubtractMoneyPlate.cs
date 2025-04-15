using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressurePlateTakeMoney : MonoBehaviour
{    
    public string itemName = "Upgrade"; // Set this in the Inspector
    public int moneyAmountRequired = 0; // Cost of the upgrade
    public GameObject floatingTextPrefab; // Assign FloatingText prefab in Inspector

    public GameObject wallPrefab; // Reference to the wall prefab
    public Transform wallSpawnPosition; // Position where the wall will spawn (can be set in the inspector)
    public bool activated; 
    private GameObject floatingTextInstance;
    private void Start()
    {
        activated = false;
        if (wallPrefab)
        {
            wallPrefab.SetActive(false);
        }
        // Spawn floating text above the pressure plate
        if (floatingTextPrefab)
        {
            floatingTextInstance = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);

            // Get FloatingText script and assign the target
            FloatingText floatingText = floatingTextInstance.GetComponent<FloatingText>();

            if (floatingText != null)
            {
                floatingText.target = transform; // Make text follow this object
                floatingText.SetText($"Buy: {itemName} - ${moneyAmountRequired}"); // Display item name and cost
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player stepped on the pressure plate
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = Color.green; // Change color when activated
            GetComponent<Collider>().enabled = false; // Disable after use
            
            // Check if the player has enough money
            if (WalletManager.Instance.SpendMoney(moneyAmountRequired))
            {
                FindObjectOfType<GroupTriggerManager>().OnTriggerActivated(gameObject);
                // Summon the wall after purchasing
                // SummonWall();
                if (wallPrefab)
                {
                    wallPrefab.SetActive(true);
                }

                // Disable the pressure plate (make it disappear)
                // DisablePressurePlate();
                DisableText();
                activated = true;
            }
            else
            {
                // Optional: Inform the player that they don't have enough money
                Debug.Log("Not enough money to activate the pressure plate.");
            }
        }
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

    private void DisablePressurePlate()
    {
        // Disable the pressure plate's collider so it can't be triggered again
        Collider plateCollider = GetComponent<Collider>();
        // if (plateCollider != null)
        // {
        //     plateCollider.enabled = false; // Disables the collider (can be re-enabled later if needed)
        // }

        // Optionally, hide or disable the pressure plate object completely
        // gameObject.SetActive(false); // Disables the entire object (can be re-enabled if needed).
    }

    private void DisableText()
    {
        if (floatingTextInstance)
        {
            Destroy(floatingTextInstance);
        }
    }
}
