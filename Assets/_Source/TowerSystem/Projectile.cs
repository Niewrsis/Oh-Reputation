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
        
        private Vector3 _target;
        private Rigidbody2D _rb;

        private float _damage;

        private bool _isSlowing;

        private void Start()
        {
            StartCoroutine(LifeTime());
            
        }
        private void FixedUpdate()
        {
            //if (!_target) return;

            Vector2 direction = (_target - transform.position).normalized;

            //_rb.velocity = direction * bulletSpeed;
        }
        public void SetTarget(Vector3 target, float damage)
        {

            _rb = GetComponent<Rigidbody2D>();
            _target = target;
            _damage = damage;
            _rb.AddForce((_target - transform.position).normalized * bulletSpeed, ForceMode2D.Impulse);
        }
        public void SetTargetAOE(float damage, float range)
        {
            _damage = damage;
            gameObject.transform.localScale = new Vector2(range * 2, range * 2);
            _isSlowing = true;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!_isSlowing)
            {
                other.GetComponent<Enemy>().TakeDamage(_damage);
            }
            else
            {
                other.GetComponent<Enemy>().TakeDamage(_damage);
                other.GetComponent<Enemy>().ReduceMovespeed(1);
            }
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();
            SR(sr);
            Destroy(gameObject);
        }
        private IEnumerator SR(SpriteRenderer sr)
        {
            Color baseColor = sr.color;
            sr.color = Color.red;
            yield return new WaitForSeconds(.2f);
            sr.color = baseColor;
        }
        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}