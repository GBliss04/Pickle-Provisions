using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int cash;
    public int balance()
    {
        return cash;
    }

    public int withdraw (int amount)
    {
        cash = cash - amount;
    }
    public int deposit (int amount)
    {
        cash = cash + amount;
    }
}
