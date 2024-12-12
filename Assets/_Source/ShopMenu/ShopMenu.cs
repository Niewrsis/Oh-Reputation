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
        }
    }
}