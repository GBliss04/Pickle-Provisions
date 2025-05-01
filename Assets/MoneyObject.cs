using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickle : MonoBehaviour
{
    public float value; // Start value, can be doubled later
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Optional: Random spin for realism
        Vector3 randomTorque = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vat"))
        {
            if (WalletManager.Instance != null)
            {
                WalletManager.Instance.AddMoney(Mathf.RoundToInt(value)); // Use updated value
            }
            else
            {
                Debug.LogWarning("WalletManager instance not found!");
            }

            Destroy(gameObject);
        }
    }
}
