using Core;
using UnityEngine;

namespace EnemySystem
{
    [RequireComponent(typeof(Rigidbody2D), typeof(EnemyMovement))]
    public class Enemy : MonoBehaviour
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float DeathReward { get; private set; }
        public float CurrentHealth { get; private set; }

        private void Start()
        {
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
            }
        }
        public void Death()
        {
            //TODO: Logic for adding money to player
            Destroy(gameObject);
        }
    }
}