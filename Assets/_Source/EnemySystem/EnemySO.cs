using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaveSystem;

namespace EnemySystem
{
    [CreateAssetMenu(fileName = "New Enemy SO", menuName = "SO/Enemy")]
    public class EnemySO : ScriptableObject
    {
        public string Name;

        [Space, Header("Settings")]
        public float MaxHealth;
        public float MovementSpeed;
        public float DeathReward;

        [Space, Header("References")]
        public GameObject Prefab;
    }
}