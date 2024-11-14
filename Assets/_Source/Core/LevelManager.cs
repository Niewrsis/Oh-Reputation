using EnemySystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
    public class LevelManager : MonoBehaviour
    {
        [field: SerializeField] public float MaxBaseHealth { get; private set; }
        [field: SerializeField] public int MaxWaves { get; private set; }

        private int _currentWave;
        public int GetCurrentWave()
        {
            return _currentWave;
        }
    }
}