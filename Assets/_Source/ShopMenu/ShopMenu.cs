using Core;
using UnityEngine;
using UnityEngine.UI;

namespace ShopMenu
{
    public class ShopMenu : MonoBehaviour
    {
        [SerializeField] private ShopSlot[] slots;
        [SerializeField] private Button[] slotsButtons;

        private void Start()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].Set();
            }

            slotsButtons[0].onClick.AddListener(AddSlot1);
            slotsButtons[1].onClick.AddListener(AddSlot2);
            slotsButtons[2].onClick.AddListener(AddSlot3);
            slotsButtons[3].onClick.AddListener(AddSlot4);
            slotsButtons[4].onClick.AddListener(AddSlot5);
            slotsButtons[5].onClick.AddListener(AddSlot6);
        }
        private void AddSlot1() { Adding(0); }
        private void AddSlot2() { Adding(1); }
        private void AddSlot3() { Adding(2); }
        private void AddSlot4() { Adding(3); }
        private void AddSlot5() { Adding(4); }
        private void AddSlot6() { Adding(5); }
        private void Adding(int index)
        {
            if (slots[index].Cost > GameManager.main.Currency) return;
            if (!GameManager.main.TryAddNewAvailableTower(slots[index].TowerPrefab)) return;
            GameManager.main.TryAddNewAvailableTower(slots[index].TowerPrefab);
            GameManager.main.RemoveCurrency(slots[index].Cost);
            GameManager.main.TryAddTowerToInventory(slots[index].TowerPrefab);
        }
    }
}