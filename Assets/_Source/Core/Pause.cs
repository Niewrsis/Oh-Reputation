using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private Button yesButton;

        private void Start()
        {
            gameObject.SetActive(true);
            yesButton.onClick.AddListener(Continue);
            Time.timeScale = 0f;
        }
        private void Continue()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}