// using UnityEngine;

// public class BuyPlate : MonoBehaviour
// {
//     public int cost = 10;
//     public GameObject objectToActivate; // The thing that gets enabled after buying

//     private bool purchased = false;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player") && !purchased)
//         {
//             if (WalletManager.Instance.SpendMoney(cost))
//             {
//                 if (objectToActivate != null)
//                 {
//                     objectToActivate.SetActive(true);
//                 }

//                 purchased = true;
//                 gameObject.SetActive(false); // Optional: remove the buy plate after purchase
//             }
//         }
//     }
// }
