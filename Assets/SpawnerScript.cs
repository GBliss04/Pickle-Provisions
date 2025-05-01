using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject objectToSpawn;       // Drag your prefab here
    public float spawnDelay = 5f;          // Time between spawns
    public bool startOnAwake = true;       // Optional toggle

    private float timer;

    void Start()
    {
        timer = spawnDelay;

        if (!startOnAwake)
        {
            enabled = false; // Disable script if not auto-starting
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Spawn();
            timer = spawnDelay;
        }
    }

    public void StartSpawning()
    {
        enabled = true;
        timer = spawnDelay;
    }

    public void StopSpawning()
    {
        enabled = false;
    }

    private void Spawn()
    {
        if (objectToSpawn != null)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("No object assigned to spawn.");
        }
    }
}
