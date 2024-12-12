using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    public class PlaceForSpawn : MonoBehaviour
    {
        public void PlaceTower()
        {
            Destroy(gameObject);
        }
    }
}