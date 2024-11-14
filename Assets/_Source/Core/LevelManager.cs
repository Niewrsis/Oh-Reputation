using EnemySystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        [field: SerializeField] public float MaxBaseHealth { get; private set; }
        [field: SerializeField] public int MaxWaves { get; private set; }

        [SerializeField] private float startCurrency;

        private Currency _currency;
        private int _currentWave;
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            _currency = new(startCurrency);
        }
        public int GetCurrentWave() { return _currentWave; }
        public void AddCurrency(float currency) { _currency.IncreaseCurrency(currency); }
        public void RemoveCurrency(float currency) { _currency.DecreaseCurrency(currency); }
    }
}