using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ShopMenu
{
    public class ShopCurrencyUI : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();

            CurrencyText();

            GameManager.main.OnCurrencyChanged += CurrencyText;
        }
        private void CurrencyText()
        {
            _text.text = GameManager.main.CurrencySystem.Currency.ToString();
        }
    }
}