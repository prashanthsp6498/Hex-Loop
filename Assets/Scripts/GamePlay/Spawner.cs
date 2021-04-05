using System;
using System.Collections.Generic;
using UnityEngine;

namespace HexLoop.GamePlay
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField] private GameObject hexagonPrefab;
        [SerializeField] private float spawnrate = 1f;
        private float nextSpawnTime = 0f;
        private Queue<GameObject> hexagonPool = new Queue<GameObject>();
        public static Action<GameObject> AddGameObjectToPool;

        private void Start()
        {
            AddGameObjectToPool = AddToPool;
            for (int i = 0; i < 5; i++)
            {
                GameObject hexagon = Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
                hexagon.SetActive(false);
                hexagonPool.Enqueue(hexagon);
            }
        }


        private void AddToPool(GameObject hexagon)
        {
            hexagon.SetActive(false);
            hexagonPool.Enqueue(hexagon);
        }


        private void Update()
        {
            if (Time.time > nextSpawnTime)
            {
                GameObject hexagon = hexagonPool.Dequeue();
                hexagon.transform.localScale = Vector3.one * 10f;
                hexagon.SetActive(true);
                nextSpawnTime = Time.time + 1f / spawnrate;
            }
        }
    }
}
