using System.Collections;
using System.Collections.Generic;
using TMPro;
using TowerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace ShopMenu
{
    [System.Serializable]
    public class ShopSlot
    {
        public TowerSO tower;

        public Image IconImage;
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI CostText;

        public void Set()
        {
            IconImage.sprite = tower.Icon;
            NameText.text = tower.Name;
            CostText.text = tower.BaseCost.ToString();
        }
    }
}