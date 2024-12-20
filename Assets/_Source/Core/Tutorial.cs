using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private Button to2Page;
        [SerializeField] private Button to1Page;
        [SerializeField] private Button exit;
        [SerializeField] private Image background;
        [SerializeField] private Sprite tutorial1;
        [SerializeField] private Sprite tutorial2;

        private void Start()
        {
            gameObject.SetActive(false);

            to1Page.onClick.AddListener(MoveToPage1);
            to2Page.onClick.AddListener(MoveToPage2);
            exit.onClick.AddListener(Exit);
        }
        private void Exit()
        {
            gameObject.SetActive(false);
        }
        private void MoveToPage2()
        {
            background.sprite = tutorial2;
        }
        private void MoveToPage1()
        {
            background.sprite = tutorial1;
        }
    }
}