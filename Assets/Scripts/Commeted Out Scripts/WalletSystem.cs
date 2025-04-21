// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro; // For TextMeshPro UI

// public class WalletSystem : MonoBehaviour
// {
//     public TextMeshProUGUI walletText;  // Reference to the TextMeshPro UI element to show the wallet balance
//     public int currentMoney = 0;  // Track the current money in the wallet
//     public int startMoney = 100;  // Starting money (can be set in the Inspector)
    
//     private void Start()
//     {
//         // Initialize the wallet with starting money and update the UI
//         currentMoney = startMoney;
//         UpdateWalletDisplay();
//     }

//     // Add money to the wallet
//     public void AddMoney(int amount)
//     {
//         currentMoney += amount;
//         UpdateWalletDisplay();
//     }

//     // Deduct money from the wallet
//     public void DeductMoney(int amount)
//     {
//         if (currentMoney >= amount)
//         {
//             currentMoney -= amount;
//             UpdateWalletDisplay();
//         }
//         else
//         {
//             // Optionally: Inform the player they don't have enough money
//             Debug.Log("Not enough money!");
//         }
//     }

//     // Update the UI to reflect the current wallet balance
//     private void UpdateWalletDisplay()
//     {
//         walletText.text = "Money: $" + currentMoney.ToString();
//     }

//     // A helper function to check if the player has enough money
//     public bool HasEnoughMoney(int amount)
//     {
//         return currentMoney >= amount;
//     }
// }
