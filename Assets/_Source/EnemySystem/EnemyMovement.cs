using UnityEngine;
using WaypointSystem;

namespace EnemySystem
{
    public class EnemyMovement : MonoBehaviour
    {
        private Waypoint _waypoint;
        private SpriteRenderer _spriteRenderer;
        private Vector3 _lastPointPosition;
        private Enemy _enemy;
        private int _currentWaypointIndex;
        private float _moveSpeed;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _moveSpeed = _enemy.MovementSpeed;

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
                _enemy.Death();
            }
        }
    }
}