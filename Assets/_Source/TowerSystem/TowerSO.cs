using System.Collections.Generic;
using TowerSystem.Upgrades;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerSystem
{
    [CreateAssetMenu(fileName = "New Tower SO", menuName = "SO/Tower")]
    public class TowerSO : ScriptableObject
    {
        public string Name;

        [Space, Header("Base Settings")]
        public float BaseDamage;
        public float BaseRange;
        public float BaseCooldown;
        public float BaseCost;
        public int MaximumCount;
        public int CurrentCount { get; set; }

        [Space, Header("AOE Settings")]
        public bool IsAOE;
        public float AOERange;

        [Space, Header("Upgrades")]
        public List<Upgrade> Upgrades;

        [Space, Header("References")]
        public GameObject Prefab;
        public Sprite Icon;
        public GameObject Projectile;
        public LayerMask EnemyLayer;

        public bool TryAddOneTower()
        {
            Debug.Log(CurrentCount);
            if(CurrentCount == MaximumCount)
            {
                Debug.LogWarning("Already full towers");
                return false;
            }

            CurrentCount++;
            return true;
        }
    }
}