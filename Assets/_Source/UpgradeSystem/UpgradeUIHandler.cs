using Core;
using System;
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
        [Header("Object")]
        [SerializeField] private GameObject menuObject;

        [Header("Image")]
        [SerializeField] private Image levelsImage;

        [Header("Buttons")]
        [SerializeField] private Button exitButton;
        [SerializeField] private Button upgradeButton;
        [SerializeField] private Button sellButton;

        [Header("Text")]
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI damageText;
        [SerializeField] private TextMeshProUGUI rangeText;
        [SerializeField] private TextMeshProUGUI cooldownText;
        [SerializeField] private TextMeshProUGUI sellCostText;
        [SerializeField] private TextMeshProUGUI upgradeCostText;

        [Header("Sprites")]
        [SerializeField] private Sprite levelOneSprite;
        [SerializeField] private Sprite levelTwoSprite;
        [SerializeField] private Sprite levelThreeSprite;
        [SerializeField] private Sprite maxLevelSprite;

        private int _towerLevel;
        private GameObject _rangeObj;
        private TowerSO _towerSO;
        private Tower _tower;

        private void Start()
        {
            menuObject.SetActive(false);
            exitButton.onClick.AddListener(SetDisabledMenu);
            upgradeButton.onClick.AddListener(TryToUpgrade);
            sellButton.onClick.AddListener(TryToSell);
            
        }
        public void SetActiveMenu(TowerSO towerSO, Tower tower, GameObject rangeObj, int towerLevel)
        {
            if(_rangeObj != null)
            {
                if (rangeObj.GetInstanceID() != _rangeObj.GetInstanceID())
                {
                    SetDisabledMenu();
                    _rangeObj = rangeObj;
                    SetActiveMenu(towerSO, tower, rangeObj, towerLevel);
                    return;
                }
            }
            
            _rangeObj = rangeObj;
            _towerSO = towerSO;
            _tower = tower;
            _towerLevel = towerLevel;

            menuObject.SetActive(true);
            _rangeObj.SetActive(true);

            DrawUpgradeCost(_towerLevel);
            DrawUI(_towerLevel);
        }
        private void SetDisabledMenu()
        {
            _rangeObj.SetActive(false);
            menuObject.SetActive(false);
        }
        public void DrawUI(int towerLevel)
        {
            _towerLevel = towerLevel;

            nameText.text = _towerSO.Name;
            if(_towerLevel != _towerSO.Upgrades.Count)
            {
                damageText.text = $"{_tower.Damage} (+{_towerSO.Upgrades[_towerLevel].PlusDamage})";
                rangeText.text = $"{_tower.Range}  (+{_towerSO.Upgrades[_towerLevel].PlusRange})";
                cooldownText.text = $"{_tower.Cooldown}  ({_towerSO.Upgrades[_towerLevel].PlusCooldown})";
                _rangeObj.transform.localScale = new Vector2(_tower.Range * 2, _tower.Range * 2);
            }
            else
            {
                damageText.text = _tower.Damage.ToString();
                rangeText.text = _tower.Range.ToString();
                cooldownText.text = _tower.Cooldown.ToString();
                _rangeObj.transform.localScale = new Vector2(_tower.Range * 2, _tower.Range * 2);
            }
            
            DrawLevel(_towerLevel);
        }
        public void DrawLevel(int towerLevel)
        {
            _towerLevel = towerLevel;
            switch(_towerLevel)
            {
                case 0:
                    {
                        levelsImage.sprite = levelOneSprite;
                        break;
                    }
                case 1:
                    {
                        levelsImage.sprite = levelTwoSprite;
                        break;
                    }
                default:
                    {
                        levelsImage.sprite = maxLevelSprite;
                        break;
                    }
            }
        }
        public void DrawUpgradeCost(int towerLevel)
        {
            _towerLevel = towerLevel;
            if (_towerLevel != _towerSO.Upgrades.Count)
            {
                upgradeCostText.text = _towerSO.Upgrades[_towerLevel].UpgradeCost.ToString() + "$";
            }
            else
            {
                upgradeCostText.text = "";
            }
            DrawUI(_towerLevel);
            DrawLevel(_towerLevel);
        }
        public void DrawSell(float sellCost)
        {
            sellCostText.text = sellCost.ToString() + "$";
        }
        private void TryToSell()
        {
            SetDisabledMenu();
            _tower.GetComponent<TowerUpgrade>().Sell();
        }
        private void TryToUpgrade()
        {
            _tower.GetComponent<TowerUpgrade>().Upgrade();
        }
    }
}