using EnemySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaypointSystem;

namespace WaveSystem
{
    public class WaveManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Waypoint waypoint;

        [Header("Settings")]
        [SerializeField] private float timeBetweenWaves;

        [Header("Waves Configuration")]
        [SerializeField] private Wave[] waves;

        private int _currentWaveID = 1;
        //private bool _isWaitingNextWave;
        //private int _enemiesAlive;

        private void Start()
        {
            SpawnEnemies();
        }
        private void SpawnEnemies()
        {
            if (!GetCurrentWave().IsRandomized)
            {
                StartCoroutine(SpawnEnemy(GetCurrentWave().FixedEnemyPrefab));
            }
            else
            {
                StartCoroutine(SpawnEnemy(GetCurrentWave().RandomizedEnemyPrefabs));
            }
        }
        private IEnumerator SpawnEnemy(GameObject enemy)
        {
            for (int i = 0; i < GetCurrentWave().EnemyCount; i++)
            {
                Instantiate(enemy, waypoint.Points[0], Quaternion.identity);
                //_enemiesAlive++;
                yield return new WaitForSeconds(GetCurrentWave().DelayBetweenSpawn);
            }
            _currentWaveID++;
            StartCoroutine(WaitUntilNextWave());
        }
        private IEnumerator SpawnEnemy(GameObject[] enemies)
        {
            for (int i = 0; i < GetCurrentWave().EnemyCount; i++)
            {
                int rnd = Random.Range(0, enemies.Length - 1);
                Instantiate(enemies[rnd], waypoint.Points[0], Quaternion.identity);
                //_enemiesAlive++;
                yield return new WaitForSeconds(GetCurrentWave().DelayBetweenSpawn);
            }
            _currentWaveID++;
            StartCoroutine(WaitUntilNextWave());
        }
        private IEnumerator WaitUntilNextWave()
        {
            //_enemiesAlive = 0;
            if (_currentWaveID > waves.Length) yield return null;
            //_isWaitingNextWave = true;
            yield return new WaitForSeconds(timeBetweenWaves);
            //_isWaitingNextWave = false;
            SpawnEnemies();
        }
        private Wave GetCurrentWave()
        {
            return waves[_currentWaveID - 1];
        }
    }
}