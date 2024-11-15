using EnemySystem;
using System;
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

        [SerializeField] private float startCurrency;

        private float _currency;
        private int _currentWave;
        private void Awake()
        {
            Instance = this;

            _currency = startCurrency;
        }
        public int GetCurrentWave() { return _currentWave; }
        public void AddCurrency(float currency) { _currency += currency; }
        public void RemoveCurrency(float currency) { _currency -= currency; }
        public float GetCurrency() { return _currency; }
    }
}