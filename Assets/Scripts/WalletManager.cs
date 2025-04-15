using UnityEngine;
using TMPro;

public class WalletManager : MonoBehaviour
{
    public static WalletManager Instance;

    public int CurrentMoney { get; private set; } = 0;

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void AddMoney(int amount)
    {
        CurrentMoney += amount;
        Debug.Log("Got some money.");
    }

    public bool SpendMoney(int amount)
    {
        if (CurrentMoney >= amount)
        {
            CurrentMoney -= amount;
            Debug.Log("Spent some money.");
            return true;
        }
        else
        {
            Debug.Log("Not enough money!");
            return false;
        }
    }
}
