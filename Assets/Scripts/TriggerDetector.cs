using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            GetComponent<Renderer>().material.color = Color.green; // Indicate activation
            GetComponent<Collider>().enabled = false; // Disable further triggers
            FindObjectOfType<GroupTriggerManager>().OnTriggerActivated(gameObject);
        }
    }
}
