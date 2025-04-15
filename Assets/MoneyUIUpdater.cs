using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUIUpdater : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI moneyText; // Assign this in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moneyText != null)
        {
            moneyText.text = "Money: $" + WalletManager.Instance.CurrentMoney;
            Debug.Log("Updating Text");
        }
    }
}
