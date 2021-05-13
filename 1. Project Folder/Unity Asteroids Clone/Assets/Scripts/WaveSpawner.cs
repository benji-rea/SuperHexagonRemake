using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float spawnRate = 1f;

    public GameObject hexagonPrefab;

    private float spawnTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnTimer)
        {
            Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            PlanetController.Rounds++;
            spawnTimer = Time.time + 1f / spawnRate;
        }
    }
}
