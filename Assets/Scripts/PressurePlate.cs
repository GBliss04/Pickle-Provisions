using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public int cost = 20; // Cost to use the plate
    public GameObject objectToSpawn; // Assign object to spawn in the Inspector
    public Transform spawnPoint; // Assign a spawn location in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player can activate it
        {
            PlayerMoney playerMoney = other.GetComponent<PlayerMoney>();
            if (playerMoney != null && playerMoney.totalMoney >= cost)
            {
                playerMoney.RemoveMoney(cost); // Deduct money
                SpawnObject();
                Destroy(gameObject); // Remove pressure plate
            }
            else
            {
                Debug.Log("Not enough money to use this pressure plate!");
            }
        }
    }

    private void SpawnObject()
    {
        if (objectToSpawn != null && spawnPoint != null)
        {
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
