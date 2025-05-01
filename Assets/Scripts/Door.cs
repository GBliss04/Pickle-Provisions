using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float moneyMultiplier; // No default value here Public multiplier variable
    private Pickle mulitpliedPickle;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the door");

        Pickle money = other.GetComponent<Pickle>();
        if (money != mulitpliedPickle)
        {
            if (money != null)
            {
                Debug.Log($"Original value: {money.value} my money mulitiplier: {moneyMultiplier}");
                money.value *= moneyMultiplier; // Use the multiplier
                Debug.Log($"New value: {money.value}");
            }
            mulitpliedPickle = money;
        }
    }
}
