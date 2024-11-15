using System.Collections;
using UnityEngine;

namespace WaveSystem
{
    [System.Serializable]
    public class Wave
    {
        [SerializeField] private string waveName;

        [Header("Configuration")]
        public int EnemyCount;
        public float DelayBetweenSpawn;
        public bool IsRandomized;

        [Header("Enemy Prefabs")]
        public GameObject FixedEnemyPrefab;
        [SerializeField] private GameObject[] randomizedEnemyPrefabs;

        public GameObject GetRandomEnemy()
        {
            int rnd = Random.Range(0, randomizedEnemyPrefabs.Length);
            return randomizedEnemyPrefabs[rnd];
        }
    }
}