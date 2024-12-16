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
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI damageText;
        [SerializeField] private TextMeshProUGUI rangeText;
        [SerializeField] private TextMeshProUGUI cooldownText;
        [SerializeField] private TextMeshProUGUI sellCostText;
        [SerializeField] private TextMeshProUGUI upgradeCostText;

        private int _towerLevel = 1;

        private void Start()
        {
            menuObject.SetActive(false);
            exitButton.onClick.AddListener(SetDisabledMenu);
        }
        public void SetActiveMenu(TowerSO tower)
        {
            menuObject.SetActive(true);
            DrawUI(tower);
        }
        private void SetDisabledMenu()
        {
            menuObject.SetActive(false);
        }
        private void DrawUI(TowerSO tower)
        {
            nameText.text = tower.name;
            levelText.text = $"Level {_towerLevel}";
            damageText.text = $"{tower.BaseDamage} (+{tower.Upgrades[_towerLevel - 1].PlusDamage})";
            rangeText.text = $"{tower.BaseRange} (+{tower.Upgrades[_towerLevel - 1].PlusRange})";
            cooldownText.text = $"{tower.BaseCooldown} ({tower.Upgrades[_towerLevel - 1].PlusCooldown})";
            upgradeCostText.text = tower.Upgrades[_towerLevel - 1].UpgradeCost.ToString();
        }
    }
}