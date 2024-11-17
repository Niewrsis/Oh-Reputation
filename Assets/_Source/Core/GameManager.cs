using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager main;
        
        [SerializeField] private float startCurrency;
       
        public float Currency { get; private set; }

        private void Awake()
        {
            if (main != null && main != this)
            {
                Destroy(this);
            }
            else
            {
                main = this;
                DontDestroyOnLoad(main);
            }

            if(PlayerPrefs.GetFloat(GlobalKeys.CURRENCY_PP_STRING) > 0)
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
        }
        public void RemoveCurrency(float amount)
        {
            Currency -= amount;
            SetCurrency();
        }
        private void SetCurrency() { PlayerPrefs.SetFloat(GlobalKeys.CURRENCY_PP_STRING, Currency); }
        private void GetCurrency() { PlayerPrefs.GetFloat(GlobalKeys.CURRENCY_PP_STRING, Currency); }
    }
}