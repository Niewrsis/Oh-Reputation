using System.Collections;
using UnityEngine;
using WaypointSystem;

namespace WaveSystem
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private Waypoint waypoint;
        [SerializeField] private Wave[] waves;

        private int _currentWaveID = 1;

        private void Start()
        {
            Debug.Log(waypoint.Points[0]);
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
                StartCoroutine(SpawnEnemy(GetCurrentWave().GetRandomEnemy()));
            }
        }
        private IEnumerator SpawnEnemy(GameObject enemy)
        {
            for (int i = 0; i < GetCurrentWave().EnemyCount; i++)
            {
                Instantiate(enemy, waypoint.Points[0], Quaternion.identity);
                yield return new WaitForSeconds(GetCurrentWave().DelayBetweenSpawn);
            }
            _currentWaveID++;
            Debug.Log("All Enemies Spawnd");
        }
        private Wave GetCurrentWave()
        {
            return waves[_currentWaveID - 1];
        }
    }
}