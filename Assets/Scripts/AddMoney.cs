using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro

public class PressurePlateGainMoney : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // Reference to the UI Text element
    public int moneyAmountToAdd = 100; // Amount of money to add when stepping on the plate
    private int totalMoney = 0; // Initial money (can be linked to a player system)

    private void Start()
    {
        // Update the money display at the start
        UpdateMoneyDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player stepped on the pressure plate
        if (other.CompareTag("Player"))
        {
            // Add money when the player steps on the plate
            AddMoney();
        }
    }

    private void AddMoney()
    {
        // Increase the total money by the specified amount
        totalMoney += moneyAmountToAdd;

        // Update the UI with the new money value
        UpdateMoneyDisplay();
    }

    private void UpdateMoneyDisplay()
    {
        // Update the TextMeshPro UI to show the current money value
        moneyText.text = "Money: $" + totalMoney.ToString();
    }
}
