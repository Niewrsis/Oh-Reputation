using Core;
using System;
using UnityEngine;

namespace EnemySystem
{
    [RequireComponent(typeof(Rigidbody2D), typeof(EnemyMovement))]
    public class Enemy : MonoBehaviour
    {
        public static Action OnEnemyDeath;
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float DeathReward { get; private set; }
        public float CurrentHealth { get; private set; }

        private void Start()
        {
            OnEnemyDeath += Death;
            CurrentHealth = MaxHealth;
        }
        public void TakeDamage(float damage)
        {
            if (CurrentHealth <= damage)
            {
                Death();
            }
            else
            {
                CurrentHealth -= damage;
                if (CurrentHealth <= damage)
                {
                    OnEnemyDeath?.Invoke();
                }
            }
        }
        public void Death()
        {
            LevelManager.Instance.AddCurrency(DeathReward);
            Debug.Log($"Current currency - {LevelManager.Instance.GetCurrency()}");
            Destroy(gameObject);
        }
        private void OnDestroy()
        {
            OnEnemyDeath -= Death;
        }
    }
}