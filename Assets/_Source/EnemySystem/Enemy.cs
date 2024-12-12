using Core;
using SceneSystem;
using System;
using UnityEngine;
using WaveSystem;
using WaypointSystem;

namespace EnemySystem
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemySO enemy;

        private Waypoint _waypoint;
        private SpriteRenderer _spriteRenderer;
        private Vector3 _lastPointPosition;
        private int _currentWaypointIndex;
        private float _moveSpeed;
        private float _currentHealth;

        private void Start()
        {
            _moveSpeed = enemy.MovementSpeed;
            _currentHealth = enemy.MaxHealth;

            _waypoint = FindObjectOfType<Waypoint>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void Update()
        {
            Move();
            Rotate();

            if (CurrenPointPositionReached())
            {
                UpdateCurrentPointIndex();
            }
        }
        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoint.GetWaypointPosition(_currentWaypointIndex), _moveSpeed * Time.deltaTime);
        }
        private void Rotate()
        {
            if (_waypoint.GetWaypointPosition(_currentWaypointIndex).x > _lastPointPosition.x)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }
        private bool CurrenPointPositionReached()
        {
            float distanceToNextPointPosition = (transform.position - _waypoint.GetWaypointPosition(_currentWaypointIndex)).magnitude;
            if (distanceToNextPointPosition < .1f)
            {
                _lastPointPosition = transform.position;
                return true;
            }
            return false;
        }
        private void UpdateCurrentPointIndex()
        {
            int lastWaypointIndex = _waypoint.Points.Length - 1;
            if (_currentWaypointIndex < lastWaypointIndex)
            {
                _currentWaypointIndex++;
            }
            else
            {
                LevelManager.Instance.RemoveBaseHP(_currentHealth);
                Death();

                if (LevelManager.Instance.GetCurrentBaseHP() <= 0)
                {
                    LevelManager.Instance.SwitchCurrentState(GameState.Lose);
                    EndGameScreen.OnGameEnd?.Invoke();
                }
            }
        }
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            if( _currentHealth <= 0 ) { Death(); }
        }
        private void Death()
        {
            LevelManager.Instance.AddCurrency(enemy.DeathReward);
            WaveManager.OnEnemyDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}