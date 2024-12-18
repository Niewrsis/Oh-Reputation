using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TowerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UpgradeSystem
{
    public class UpgradeUIHandler : MonoBehaviour
    {
        [SerializeField] private GameObject menuObject;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button upgradeButton;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI damageText;
        [SerializeField] private TextMeshProUGUI rangeText;
        [SerializeField] private TextMeshProUGUI cooldownText;
        [SerializeField] private TextMeshProUGUI sellCostText;
        [SerializeField] private TextMeshProUGUI upgradeCostText;

        private int _towerLevel;
        private GameObject _rangeObj;
        private TowerSO _towerSO;
        private Tower _tower;

        private void Start()
        {
            menuObject.SetActive(false);
            exitButton.onClick.AddListener(SetDisabledMenu);
            upgradeButton.onClick.AddListener(Upgrade);
        }
        public void SetActiveMenu(TowerSO towerSO, Tower tower, GameObject rangeObj)
        {
            _rangeObj = rangeObj;
            _towerSO = towerSO;
            _tower = tower;

            menuObject.SetActive(true);
            _rangeObj.SetActive(true);

            if (_towerLevel != _towerSO.Upgrades.Count)
            {
                upgradeCostText.text = $"{_towerSO.Upgrades[_towerLevel].UpgradeCost}$";
            }
            else
            {
                upgradeCostText.text = "Max level";
            }

            DrawUI();
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
            DrawUI();

            _towerLevel++;

            if (_towerLevel != _towerSO.Upgrades.Count)
            {
                upgradeCostText.text = $"{_towerSO.Upgrades[_towerLevel].UpgradeCost}$";
            }
            else
            {
                upgradeCostText.text = "Max level";
            }
        }
        private void SetDisabledMenu()
        {
            _rangeObj.SetActive(false);
            menuObject.SetActive(false);
        }
        private void DrawUI()
        {
            nameText.text = _towerSO.Name;
            levelText.text = $"Level {_towerLevel + 1}";
            damageText.text = $"{_tower.Damage} (+{_towerSO.Upgrades[_towerLevel].PlusDamage})";
            rangeText.text = $"{_tower.Range}  (+ {_towerSO.Upgrades[_towerLevel].PlusRange})";
            cooldownText.text = $"{_tower.Cooldown}  ( {_towerSO.Upgrades[_towerLevel].PlusCooldown})";
            _rangeObj.transform.localScale = new Vector2(_tower.Range * 2, _tower.Range * 2);
        }
    }
}