using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem.View
{
    public class TowerIcon : MonoBehaviour
    {
        [SerializeField] private Sprite icon;

        [SerializeField] private Image towerIcon;
        [SerializeField] private TextMeshProUGUI costText;

        private float _cost;

        public void Construct(float cost)
        {
            _cost = cost;
            Draw();
        }
        private void Draw()
        {
            costText.text = _cost.ToString();
            //towerIcon.sprite = icon;
        }
    }
}