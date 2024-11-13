using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EnemySystem
{
    public class EnemyHealthContainer : MonoBehaviour
    {
        [SerializeField] private Image fillAmountImage;
        public Image FillAmountImage => fillAmountImage;
    }
}