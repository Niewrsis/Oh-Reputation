using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using WaypointSystem;

namespace EnemySystem
{
    public class Enemy : MonoBehaviour
    {
        public static Action<Enemy> OnEndReached;

        public float MoveSpeed = 2f;
        public float DeathCoinReward = 2f;
        
        private Waypoint _waypoint;
        private SpriteRenderer _spriteRenderer;
        private Vector3 _lastPointPosition;
        private EnemyHealth _enemyHealth;
        private int _currentWaypointIndex;

        private void Start()
        {
            _waypoint = FindObjectOfType<Waypoint>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _enemyHealth = GetComponent<EnemyHealth>();
        }
        private void Update()
        {
            Move();
            Rotate();

            if(CurrenPointPositionReached())
            {
                UpdateCurrentPointIndex();
            }
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoint.GetWaypointPosition(_currentWaypointIndex), MoveSpeed * Time.deltaTime);
        }
        private void Rotate()
        {
            if(_waypoint.GetWaypointPosition(_currentWaypointIndex).x > _lastPointPosition.x)
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
            if(distanceToNextPointPosition < .1f)
            {
                _lastPointPosition = transform.position;
                return true;
            }
            return false;
        }
        private void UpdateCurrentPointIndex()
        {
            int lastWaypointIndex = _waypoint.Points.Length - 1;
            if(_currentWaypointIndex < lastWaypointIndex)
            {
                _currentWaypointIndex++;
            }
            else
            {
                EndPointReached();
            }
        }
        private void EndPointReached()
        {
            OnEndReached?.Invoke(this);
            _enemyHealth.Die();
            ObjectPooler.ReturnToPool(gameObject);
        }
    }
}