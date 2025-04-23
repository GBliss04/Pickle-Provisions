using UnityEngine;
using TMPro;

public class WalletManager : Subject
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
        NotifyObservers(WalletActions.AddMoney);
    }

    public bool SpendMoney(int amount)
    {
        if (CurrentMoney >= amount)
        {
            CurrentMoney -= amount;
            NotifyObservers(WalletActions.SubtractMoney);
            return true;
        }
        else
        {
            NotifyObservers(WalletActions.InsufficientFunds);
            return false;
        }
    }
}
