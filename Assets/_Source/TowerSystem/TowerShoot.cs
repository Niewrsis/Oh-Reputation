using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UpgradeSystem;

namespace TowerSystem
{
    public class TowerShoot : MonoBehaviour
    {
        private TowerSO _towerSO;
        private Tower _tower;
        private Transform _target;
        private bool _isShooting;
        private SpriteRenderer _sr;
        private Animator _animator;

        private void Start()
        {
            _sr = GetComponent<SpriteRenderer>();
            _tower = GetComponent<Tower>();
            _animator = GetComponent<Animator>();
            _towerSO = _tower.TowerSO;
        }
        private void Update()
        {
            Rotate();
            if (_target == null)
            {
                FindTarget();
                return;
            }

            if(!CheckTagetIsInRange())
            {
                _target = null;
            }
            else
            {
                if (!_isShooting) StartCoroutine(Reloading());
            }
        }
        private void FindTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _tower.Range, transform.forward, 0f, _towerSO.EnemyLayer);

            if(hits.Length > 0)
            {
                _target = hits[0].transform;
            }
        }
        private bool CheckTagetIsInRange()
        {
            return Vector2.Distance(_target.position, transform.position) <= _tower.Range;
        }
        private void Shoot()
        {
            GameObject bulletObj = Instantiate(_towerSO.Projectile, transform.position, Quaternion.identity);
            Projectile bullet = bulletObj.GetComponent<Projectile>();
            bullet.SetTarget(_target.position, _tower.Damage);
        }
        private IEnumerator Reloading()
        {
            _isShooting = true;
            Shoot();
            _animator.SetTrigger("Attack");
            yield return new WaitForSeconds(_tower.Cooldown);
            _isShooting = false;
        }
        private void Rotate()
        {
            if(_target == null) return;

            if(_target.position.x - transform.position.x > 0)
            {
                _sr.flipX = true;
            }
            else
            {
                _sr.flipX = false;
            }
        }
    }
}