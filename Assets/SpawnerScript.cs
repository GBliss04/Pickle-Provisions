using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public GameObject moneyPrefab; // Assign the money object prefab
    public Transform spawnPoint; // Assign the spawn location
    public float spawnInterval = 10f; // Time in seconds

    private void Start()
    {
        StartCoroutine(SpawnMoney());
    }

    private IEnumerator SpawnMoney()
    {
        while (true) // Infinite loop to keep spawning
        {
            yield return new WaitForSeconds(spawnInterval); // Wait before spawning

            if (moneyPrefab != null && spawnPoint != null)
            {
                Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
