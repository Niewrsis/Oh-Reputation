using System.Collections;
using System.Collections.Generic;
using UISystem;
using UnityEngine;

namespace Core
{
    public class CurrencySystem
    {
        public float Currency { get; private set; }

        private GameManager _gameManger;
        public CurrencySystem(float startCurrency)
        {
            if (PlayerPrefs.GetFloat(GlobalKeys.CURRENCY_PP_STRING) > 0)
            {
                GetCurrency();
            }
            else
            {
                Currency = startCurrency;
                SetCurrency();
            }
        }
        public void AddCurrency(float amount)
        {
            Currency += amount;
            SetCurrency();
            _gameManger.OnCurrencyChanged?.Invoke();
        }
        public void RemoveCurrency(float amount)
        {
            Currency -= amount;
            SetCurrency();
            _gameManger.OnCurrencyChanged?.Invoke();
        }
        private void SetCurrency() { PlayerPrefs.SetFloat(GlobalKeys.CURRENCY_PP_STRING, Currency); }
        private void GetCurrency() { PlayerPrefs.GetFloat(GlobalKeys.CURRENCY_PP_STRING, Currency); }
    }
}