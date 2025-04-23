// using UnityEngine;
// using TMPro;

// public class TriggerObject : MonoBehaviour
// {


  
//     void Start()
//     {
//         activated = false;
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
            

//             // Check if the player has enough money
//             if (WalletManager.Instance.SpendMoney(cost))
//             {
//                 // Summon the wall after purchasing
//                 SummonWall();

//                 // Disable the pressure plate (make it disappear)
//                 DisablePressurePlate();
//                 activated = true;
//             }
//             else
//             {
//                 // Optional: Inform the player that they don't have enough money
//                 Debug.Log("Not enough money to activate the pressure plate.");
//             }
//         }
//     }

//     private void SummonWall()
//     {
//         // Instantiate the wall prefab at the designated spawn position
//         if (wallPrefab != null && wallSpawnPosition != null)
//         {
//             Instantiate(wallPrefab, wallSpawnPosition.position, wallSpawnPosition.rotation);
//         }
//         else
//         {
//             Debug.LogWarning("Wall prefab or spawn position is not set.");
//         }
//     }

//     private void DisablePressurePlate()
//     {
//         // Disable the pressure plate's collider so it can't be triggered again
//         Collider plateCollider = GetComponent<Collider>();
//         if (plateCollider != null)
//         {
//             plateCollider.enabled = false; // Disables the collider (can be re-enabled later if needed)
//         }

//         // Optionally, hide or disable the pressure plate object completely
//         gameObject.SetActive(false); // Disables the entire object (can be re-enabled if needed).
//     }

// }
