using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem.Upgrades
{
    [System.Serializable]
    public class Upgrade
    {
        public float PlusDamage;
        public float PlusRange;
        public float PlusCooldown;
        public float UpgradeCost;
    }
}