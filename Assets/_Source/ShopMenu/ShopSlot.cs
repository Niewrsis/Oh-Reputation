using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopMenu
{
    [System.Serializable]
    public class ShopSlot
    {
        public string Name;
        public float Cost;
        public Sprite Icon;
        public GameObject TowerPrefab;

        public Image IconImage;
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI CostText;

        public void Set()
        {
            IconImage.sprite = Icon;
            NameText.text = Name;
            CostText.text = Cost.ToString();
        }
    }
}