using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UIMangager
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyText;

        private void Update()
        {
            moneyText.text = LevelManager.Instance.GetCurrency().ToString();
        }
    }
}