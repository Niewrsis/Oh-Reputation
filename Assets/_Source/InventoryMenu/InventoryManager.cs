using Core;
using System.Collections;
using System.Collections.Generic;
using TowerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryMenu
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private Image slot1Image;
        [SerializeField] private Image slot2Image;
        [SerializeField] private Image slot3Image;

        private int slotIndex;

        public void SetSlotIndex(int index) { slotIndex = index; }
        private void FillInventory()
        {
            for (int i = 0; i < GameManager.main.GetCurrentInventoryTowers().Length; i++)
            {
                if (GameManager.main.GetCurrentInventoryTowers()[i] != null)
                {
                    slot1Image.sprite = GameManager.main.GetCurrentInventoryTowers()[i].GetComponent<Tower>().Icon;
                }
            }
        }
    }
}