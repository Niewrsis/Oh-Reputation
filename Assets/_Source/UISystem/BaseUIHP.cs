using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UISystem
{
    public class BaseUIHP : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hpText;

        private void Update()
        {
            hpText.text = LevelManager.Instance.GetCurrentBaseHP().ToString();
        }
    }
}