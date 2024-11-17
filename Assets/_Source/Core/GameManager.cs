using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager main;

        public UnityAction OnCurrencyChanged;

        [SerializeField] private float startCurrency;
        [SerializeField] private List<GameObject> allTowers;

        private GameObject[] _currentInventoryTowers = new GameObject[3];
        private List<GameObject> _availableTowers = new List<GameObject>();
       
        public float Currency { get; private set; }

        private void Awake()
        {
            if (main != null && main != this)
            {
                Destroy(this);
            }
            else
            {
                main = this;
                DontDestroyOnLoad(main);
            }

            if(PlayerPrefs.GetFloat(GlobalKeys.CURRENCY_PP_STRING) > 0)
            {
                GetCurrency();
            }
            else
            {
                Currency = startCurrency;
                SetCurrency();
            }
            for(int i = 0;  i < _currentInventoryTowers.Length - 1; i++)
            {
                _currentInventoryTowers[i] = null;
            }

            _availableTowers.Add(allTowers[0]);
            CheckTowers();
        }
        public void AddCurrency(float amount)
        {
            Currency += amount;
            SetCurrency();
            OnCurrencyChanged?.Invoke();
        }
        public void RemoveCurrency(float amount)
        {
            Currency -= amount;
            SetCurrency();
            OnCurrencyChanged?.Invoke();
        }
        private void SetCurrency() { PlayerPrefs.SetFloat(GlobalKeys.CURRENCY_PP_STRING, Currency); }
        private void GetCurrency() { PlayerPrefs.GetFloat(GlobalKeys.CURRENCY_PP_STRING, Currency); }
        private void CheckTowers()
        {
            for (int i = 0; i < allTowers.Count; i++)
            {
                for(int j = 0; j < allTowers.Count; j++)
                {
                    if(allTowers[i] == allTowers[j])
                    {
                        if(i != j)
                        {
                            if (allTowers[j] != null)
                            {
                                Debug.Log("Tower was deleted " + allTowers[j].name);
                                allTowers[j] = null;
                            }
                        }
                    }
                }
            }
            DeleteNull(allTowers);
        }
        private void DeleteNull(List<GameObject> towers)
        {
            if (towers[towers.Count - 1] != null) return;

            towers.Remove(towers[towers.Count - 1]);
            DeleteNull(towers);
        }
        public bool TryAddNewAvailableTower(GameObject newAvailableTower)
        {
            for(int i = 0; i < _availableTowers.Count - 1; i++)
            {
                if (_availableTowers[i] == newAvailableTower)
                {
                    Debug.LogWarning("This tower already available");
                    return false;
                }
            }
            _availableTowers.Add(newAvailableTower);
            return true;
        }
        public GameObject[] GetAllInventoryTowers() { return _currentInventoryTowers; }
        public void TryAddTowerToInventory(GameObject tower)
        {
            //if (_currentInventoryTowers.Length >= 3) throw new Exception("Inventory already full");
            for (int i = 0; i < _currentInventoryTowers.Length - 1; i++)
            {
                if( _currentInventoryTowers[i] ==  tower) throw new Exception("This tower already in inventory");
            }
            for (int i = 0; i < _currentInventoryTowers.Length - 1; i++)
            {
                if (_currentInventoryTowers[i] == null)
                {
                    _currentInventoryTowers[i] = tower;
                    break;
                }
            }
        }
        public void TryAddTowerToInventory(GameObject tower, int slot)
        {
            if (_currentInventoryTowers[slot - 1] == tower) Debug.LogWarning("This tower already at this slot");

            _currentInventoryTowers[slot - 1] = tower;
        }
    }
}