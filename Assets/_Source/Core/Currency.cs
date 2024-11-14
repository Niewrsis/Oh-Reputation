using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Currency
    {
        private float _currency;
        public Currency(float currency)
        {
            _currency = currency;
        }
        public void IncreaseCurrency(float currency)
        {
            _currency += currency;
        }
        public void DecreaseCurrency(float currency)
        {
            if (currency > _currency) throw new Exception("Higher then current currency");

            _currency -= currency;
        }
        public float GetCurrency() { return _currency; }
    }
}