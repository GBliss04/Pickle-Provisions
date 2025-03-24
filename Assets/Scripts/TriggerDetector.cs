using UnityEngine;
using TMPro;

public class TriggerObject : MonoBehaviour
{
    public string itemName = "Upgrade"; // Set this in the Inspector
    public int cost = 50; // Cost of the upgrade
    public GameObject floatingTextPrefab; // Assign FloatingText prefab in Inspector

    private GameObject floatingTextInstance;

    void Start()
    {
        // Spawn floating text above the pressure plate
        if (floatingTextPrefab)
        {
            floatingTextInstance = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);

            // Get FloatingText script and assign the target
            FloatingText floatingText = floatingTextInstance.GetComponent<FloatingText>();

            if (floatingText != null)
            {
                floatingText.target = transform; // Make text follow this object
                floatingText.SetText($"Buy: {itemName} - ${cost}"); // Display item name and cost
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = Color.green; // Change color when activated
            GetComponent<Collider>().enabled = false; // Disable after use
            
            FindObjectOfType<GroupTriggerManager>().OnTriggerActivated(gameObject);

            // Destroy floating text when item is purchased
            if (floatingTextInstance)
            {
                Destroy(floatingTextInstance);
            }
        }
    }
}
