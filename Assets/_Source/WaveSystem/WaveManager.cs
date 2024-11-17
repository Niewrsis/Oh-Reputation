using Core;
using EnemySystem;
using SceneSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UISystem;
using UnityEngine;
using UnityEngine.Events;
using WaypointSystem;

namespace WaveSystem
{
    public class WaveManager : MonoBehaviour
    {
        public static UnityAction OnEnemyDeath;

        [Header("References")]
        [SerializeField] private Waypoint waypoint;

        [Header("Settings")]
        [SerializeField] private float timeBetweenWaves;

        [Header("Waves Configuration")]
        [SerializeField] private Wave[] waves;

        private int _currentWaveID = 1;
        private int _enemiesAlive;

        private void Start()
        {
            OnEnemyDeath += EnemyDied;
            WavesUI.OnWavesDraw?.Invoke();
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
                _enemiesAlive++;
                yield return new WaitForSeconds(GetCurrentWave().DelayBetweenSpawn);
            }
            _currentWaveID++;
            StartCoroutine(WaitUntilNextWave());
        }
        private IEnumerator SpawnEnemy(GameObject[] enemies)
        {
            for (int i = 0; i < GetCurrentWave().EnemyCount; i++)
            {
                int rnd = UnityEngine.Random.Range(0, enemies.Length - 1);
                Instantiate(enemies[rnd], waypoint.Points[0], Quaternion.identity);
                _enemiesAlive++;
                yield return new WaitForSeconds(GetCurrentWave().DelayBetweenSpawn);
            }
            _currentWaveID++;
            StartCoroutine(WaitUntilNextWave());
        }
        private IEnumerator WaitUntilNextWave()
        {
            if (_currentWaveID > waves.Length)
            {
                StartCoroutine(WaitToAllEnemiesDeath());
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(timeBetweenWaves);
                WavesUI.OnWavesDraw?.Invoke();
                SpawnEnemies();
            }
        }
        private IEnumerator WaitToAllEnemiesDeath()
        {
            while(_enemiesAlive > 0)
            {
                yield return new WaitForSeconds(.1f);
            }
            LevelManager.Instance.SwitchCurrentState(GameState.Win);
            yield return new WaitForSeconds(1f);
            EndGameScreen.OnGameEnd?.Invoke();
        }
        private Wave GetCurrentWave()
        {
            return waves[_currentWaveID - 1];
        }
        public int GetCurrentWaveID()
        {
            return _currentWaveID;
        }
        private void EnemyDied()
        {
            _enemiesAlive--;
        }
    }
}