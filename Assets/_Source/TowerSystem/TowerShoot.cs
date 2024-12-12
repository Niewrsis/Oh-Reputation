using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TowerSystem
{
    public class TowerShoot : MonoBehaviour
    {
        [SerializeField] private TowerSO tower;

        [Header("References")]
        [SerializeField] private GameObject rangeObj;

        private float _damage;
        private float _range;
        private float _cooldown;

        private Transform _target;
        private bool _isShooting;

        private void Start()
        {
            _damage = tower.BaseDamage;
            _range = tower.BaseRange;
            _cooldown = tower.BaseCooldown;

            rangeObj.transform.localScale = new Vector2(_range * 2, _range * 2);
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
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _range, transform.forward, 0f, tower.EnemyLayer);

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
            GameObject bulletObj = Instantiate(tower.Projectile, transform.position, Quaternion.identity);
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
    }
}