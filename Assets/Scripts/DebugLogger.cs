using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogger : MonoBehaviour, IObserver
{
    // Start is called before the first frame update
    void Start()
    {
        WalletManager.Instance.AddObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNotify(WalletActions action)
    {
        if (action == WalletActions.AddMoney)
        {
            Debug.Log("Added Money");
        }
        if (action == WalletActions.SubtractMoney)
        {
            Debug.Log("Subtract Money");
        }
    }
}
