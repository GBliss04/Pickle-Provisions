// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro; // Import TextMeshPro

// public class PlayerMoney : MonoBehaviour
// {
//     public int totalMoney = 0;
//     public TextMeshProUGUI moneyText; // Reference to TMP UI text

//     private void Start()
//     {
//         UpdateMoneyText();
//     }

//     public void AddMoney(int amount)
//     {
//         totalMoney += amount;
//         UpdateMoneyText();
//     }

//     private void UpdateMoneyText()
//     {
//         if (moneyText != null)
//         {
//             moneyText.text = "Money: $" + totalMoney;
//         }
//     }
//     public void RemoveMoney(int amount)
//     {
//         totalMoney -= amount;
//         UpdateMoneyText();
//     }
// }
