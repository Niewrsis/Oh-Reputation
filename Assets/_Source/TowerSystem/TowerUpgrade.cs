using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UpgradeSystem;

namespace TowerSystem
{
    public class TowerUpgrade : MonoBehaviour
    {
        [SerializeField] private GameObject rangeObj;

        private Tower _tower;
        private TowerSO _towerSO;
        private int _towerLevel;
        private UpgradeUIHandler _upgradeUIHandler;

        private float _sellCost;

        private void Start()
        {
            _tower = GetComponent<Tower>();
            _towerSO = _tower.TowerSO;
            _upgradeUIHandler = FindObjectOfType<UpgradeUIHandler>();

            rangeObj.SetActive(false);
            rangeObj.transform.localScale = new Vector2(_tower.Range * 2, _tower.Range * 2);

            IncreaseSellCost(_towerSO.BaseCost);
        }
        public void Upgrade()
        {
            if (_tower == null) return;
            if (_towerLevel == _towerSO.Upgrades.Count)
            {
                Debug.Log("Maximum level of upgrades");
                return;
            }
            if (_towerSO.Upgrades[_towerLevel].UpgradeCost > LevelManager.Instance.GetCurrency())
            {
                Debug.Log("Not enough money");
                return;
            }

            LevelManager.Instance.RemoveCurrency(_towerSO.Upgrades[_towerLevel].UpgradeCost);
            _tower.Range += _towerSO.Upgrades[_towerLevel].PlusRange;
            _tower.Damage += _towerSO.Upgrades[_towerLevel].PlusDamage;
            _tower.Range += _towerSO.Upgrades[_towerLevel].PlusCooldown;

            _upgradeUIHandler.DrawUI(_towerLevel);
            IncreaseSellCost(_towerSO.Upgrades[_towerLevel].UpgradeCost);

            _towerLevel++;

            _upgradeUIHandler.DrawUpgradeCost(_towerLevel);
        }
        public void Sell()
        {
            LevelManager.Instance.AddCurrency(_sellCost);
            _towerSO.CurrentCount--;
            Destroy(gameObject);
        }
        private void OnMouseDown()
        {
            _upgradeUIHandler.SetActiveMenu(_towerSO, _tower, rangeObj, _towerLevel);
        }
        private void IncreaseSellCost(float addedCost)
        {
            _sellCost += Mathf.RoundToInt(addedCost / 2);
            _upgradeUIHandler.DrawSell(_sellCost);
        }
    }
}