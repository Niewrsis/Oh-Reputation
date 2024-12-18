using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    public class Tower : MonoBehaviour
    {
        public TowerSO TowerSO;

        public float Damage { get; set; }
        public float Range { get; set; }
        public float Cooldown { get; set; }
        private void Awake()
        {
            Damage = TowerSO.BaseDamage;
            Range = TowerSO.BaseRange;
            Cooldown = TowerSO.BaseCooldown;
        }
    }
}