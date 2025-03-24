using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public Transform target; // The object this text follows
    public Vector3 offset = new Vector3(0, 2f, 0); // Height above the object

    void LateUpdate()
    {
        if (target != null)
        {
            // Keep text above the target position
            transform.position = target.position + offset;
        }

        if (Camera.main != null)
        {
            // Make text always face the player's camera
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0); // Prevents flipping
        }
    }

    public void SetText(string text)
    {
        GetComponentInChildren<TextMeshPro>().text = text;
    }
}
