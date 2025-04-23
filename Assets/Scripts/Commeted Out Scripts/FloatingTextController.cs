// using UnityEngine;
// using TMPro;

// public class FloatingTextController : MonoBehaviour
// {
//     public Transform target; // Assign the pressure plate as the target
//     private TextMeshPro textMesh;

//     void Start()
//     {
//         textMesh = GetComponent<TextMeshPro>();
//     }

//     void Update()
//     {
//         if (target != null)
//         {
//             // Make text face the player
//             transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
//         }
//     }

//     public void SetText(string text)
//     {
//         if (textMesh != null)
//         {
//             textMesh.text = text;
//         }
//     }
// }
