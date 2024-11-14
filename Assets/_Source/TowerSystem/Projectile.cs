using EnemySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float lifeTime;
        
        private Transform _target;
        private Rigidbody2D _rb;

        private float _damage;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            if (!_target) return;

            Vector2 direction = (_target.position - transform.position).normalized;

            _rb.velocity = direction * bulletSpeed;
        }
        public void SetTarget(Transform target, float damage)
        {
            _target = target;
            _damage = damage;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<Enemy>().TakeDamage(_damage);
            Destroy(gameObject);
        }
        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}