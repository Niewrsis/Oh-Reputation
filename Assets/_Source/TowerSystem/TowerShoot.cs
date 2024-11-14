using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TowerSystem
{
    public class TowerShoot : MonoBehaviour
    {
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private GameObject projectile;

        private Tower _tower;
        private float _damage;
        private float _range;
        private float _cooldown;

        private Transform _target;
        private bool _isShooting;

        private void Start()
        {
            _tower = GetComponent<Tower>();

            _damage = _tower.Damage;
            _range = _tower.Range;
            _cooldown = _tower.Cooldown;
        }
        private void Update()
        {
            if(_target == null)
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
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _range, transform.forward, 0f, enemyLayer);

            if(hits.Length > 0)
            {
                _target = hits[0].transform;
            }
        }
        private bool CheckTagetIsInRange()
        {
            return Vector2.Distance(_target.position, transform.position) <= _range;
        }
        private void Shoot()
        {
            GameObject bulletObj = Instantiate(projectile, transform.position, Quaternion.identity);
            Projectile bullet = bulletObj.GetComponent<Projectile>();
            bullet.SetTarget(_target, _damage);
        }
        private IEnumerator Reloading()
        {
            _isShooting = true;
            Shoot();
            yield return new WaitForSeconds(_cooldown);
            _isShooting = false;
        }
        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.cyan;
            Handles.DrawWireDisc(transform.position, transform.forward, _range);
        }
    }
}