using Core;
using System.Collections;
using System.Collections.Generic;
using TowerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private Image slot1Image;
        [SerializeField] private Image slot2Image;
        [SerializeField] private Image slot3Image;

        [Header("Towers")]
        [SerializeField] private List<TowerSO> allTowers;

        private List<TowerSO> _availableTowers;
        private List<TowerSO> _currentTowers;

        private int _index;

        private void Start()
        {
            CheckForRepeatingTowers();
        }
        private void CheckForRepeatingTowers()
        {
            for(int i = 0; i < allTowers.Count; i++)
            {
                for(int j = 0; j < allTowers.Count; j++)
                {
                    if(allTowers[i] == allTowers[j] && i != j)
                    {
                        allTowers[j] = null;
                    }
                }
            }
            RemoveNulls(allTowers);
        }
        private void RemoveNulls(List<TowerSO> towers)
        {
            if (_index == towers.Count - 1) return;

            if (towers[_index] == null)
            {
                Debug.Log("Tower removed " + towers[_index].name);
                towers.RemoveAt(_index);
                _index = 0;
            }
            else
            {
                _index++;
            }
            RemoveNulls(towers);
        }
    }
}