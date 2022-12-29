using System;
using UnityEngine;
using System.Collections.Generic;
using HexLoop.Core.ManagerUtil;

namespace HexLoop.Core.GamePlay
{
    public class Spawner : MonoBehaviour, IFactoryItem
    {

        [SerializeField] private GameObject hexagonPrefab;
        [SerializeField] private float spawnrate = 1f;

        private float _nextSpawnTime = 0f;
        private readonly Queue<GameObject> _hexagonPool = new();

        private void OnEnable() => SubscribeToManager();

        private void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject hexagon = Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
                hexagon.SetActive(false);
                _hexagonPool.Enqueue(hexagon);
            }
        }

        public void AddToPool(GameObject hexagon)
        {
            hexagon.SetActive(false);
            _hexagonPool.Enqueue(hexagon);
        }

        private void Update()
        {
            if (Time.time <= _nextSpawnTime)
                return;

            GameObject hexagon = _hexagonPool.Dequeue();
            hexagon.transform.localScale = Vector3.one * 10f;
            hexagon.SetActive(true);
            _nextSpawnTime = Time.time + 1f / spawnrate;
        }

        public void SubscribeToManager() => GameFactory.Subscribe(this);
    }
}
