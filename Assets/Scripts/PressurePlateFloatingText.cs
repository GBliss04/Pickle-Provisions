using UnityEngine;
using TMPro;

public class PressurePlateFloatingText : MonoBehaviour
{
    // public GameObject floatingTextPrefab; // Assign this in the Inspector
    public string displayText = "+$50 per press"; // Customize the text
    // private GameObject floatingTextInstance;
    void Start()
    {
        // Make sure a floating text prefab is assigned
        // if (floatingTextPrefab != null)
        // {
            // Instantiate the floating text above the pressure plate
            // floatingTextInstance = Instantiate(floatingTextPrefab, transform.position + new Vector3(0, 2f, 0), Quaternion.identity);
            
            // Make sure the text always faces the player
            FloatingText text = gameObject.GetComponent<FloatingText>();
            if (text != null)
            {
                text.SetText(displayText);
                text.target = transform; // Attach text to the pressure plate
            }
        // }
        // else
        // {
        //     Debug.LogError("Floating Text Prefab is not assigned to " + gameObject.name);
        // }
    }
}
