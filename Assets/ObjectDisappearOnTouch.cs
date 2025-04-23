using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisappearOnTouch : MonoBehaviour
{
    // You can specify the object you want to detect in the inspector (e.g., a specific tag or object type)
    public string targetTag = "Player";  // Target tag for the object to disappear when it touches (you can set this in the Inspector)

    // This method is called when the object enters a collision with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the specified tag
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Hide or destroy this object when the collision occurs
            Destroy(gameObject);  // This destroys the object the script is attached to
        }
    }

    // If you're using triggers instead of regular colliders, you can use OnTriggerEnter instead:
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Destroy(gameObject); // Destroys the object when it touches a trigger collider with the specified tag
        }
    }
    */
}
