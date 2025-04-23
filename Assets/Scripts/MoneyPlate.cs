using UnityEngine;

public class MoneyPlate : MonoBehaviour
{
    public int moneyPerPress = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WalletManager.Instance.AddMoney(moneyPerPress);
        }
    }
}
