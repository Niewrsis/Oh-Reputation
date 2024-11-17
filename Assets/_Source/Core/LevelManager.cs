using UnityEngine;

namespace Core
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        [field: SerializeField] public float MaxBaseHealth { get; private set; }
        [field: SerializeField] public float MaxLevelReward { get; private set; }
        [field: SerializeField] public float MinLevelReward { get; private set; }

        [SerializeField] private float startCurrency;

        public GameState CurrentGameState { get; private set; }

        private float _currency;
        private float _currentBaseHP;
        private void Awake()
        {
            Instance = this;

            _currentBaseHP = MaxBaseHealth;
            CurrentGameState = GameState.InGame;
            _currency = startCurrency;
        }
        public void AddCurrency(float currency) { _currency += currency; }
        public void RemoveCurrency(float currency) { _currency -= currency; }
        public void RemoveBaseHP(float damage) { _currentBaseHP -= damage; }
        public float GetCurrency() { return _currency; }
        public float GetCurrentBaseHP() { return _currentBaseHP; }
        public void SwitchCurrentState(GameState state) { CurrentGameState = state; }
    }
}