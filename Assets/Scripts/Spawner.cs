using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject hexagonPrefab;
    [SerializeField] float spawnrate = 1f;
    float nextSpawnTime = 0f;
    

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            nextSpawnTime = Time.time + 1f / spawnrate;
        }
    }
}
