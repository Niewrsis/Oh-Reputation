using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem.View
{
    public class TowerIcon : MonoBehaviour
    {

        [SerializeField] private Image towerIcon;
        [SerializeField] private TextMeshProUGUI costText;

        private Sprite _icon;
        private float _cost;

        public void Construct(TowerSO tower)
        {
            //_icon = tower.Icon;
            _cost = tower.BaseCost;
            Draw();
        }
        private void Draw()
        {
            costText.text = _cost.ToString();
            //towerIcon.sprite = icon;
        }
    }
}