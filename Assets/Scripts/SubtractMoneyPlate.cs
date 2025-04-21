using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressurePlateTakeMoney : MonoBehaviour
{    
    public string itemName = "Upgrade"; // Set this in the Inspector
    public int moneyAmountRequired = 0; // Cost of the upgrade
    public GameObject wallPrefab; // Reference to the wall prefab
    public bool activated; 
    private GameObject floatingTextInstance;
    private void Start()
    {
        // Get FloatingText script and assign the target
        // FloatingText floatingText = GetComponent<FloatingText>();
        FloatingText floatingText = GetComponentInChildren<FloatingText>();

        if (floatingText != null)
        {
            floatingText.target = transform; // Make text follow this object
            floatingText.SetText($"Buy: {itemName} - ${moneyAmountRequired}"); // Display item name and cost
            Debug.Log("floating text isn't null");
        }
         activated = false;
        if (wallPrefab)
        {
            wallPrefab.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player stepped on the pressure plate
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = Color.green; // Change color when activated
            Debug.Log("Trying to spend money");
            // Check if the player has enough money
            if (WalletManager.Instance.SpendMoney(moneyAmountRequired))
            {
                Debug.Log("Spent some money");
                FindObjectOfType<GroupTriggerManager>().OnTriggerActivated(gameObject);
                // Summon the wall after purchasing
                // SummonWall();
                if (wallPrefab)
                {
                    wallPrefab.SetActive(true);
                }

                // Disable the pressure plate (make it disappear)
                DisablePressurePlate();
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

    private void DisableText()
    {
        if (floatingTextInstance)
        {
            Destroy(floatingTextInstance);
        }
    }
}
