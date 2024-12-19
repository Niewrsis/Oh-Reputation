using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SceneSystem
{
    public class EndGameScreenButtons : MonoBehaviour
    {
        [SerializeField] private Button returnButton;
        [SerializeField] private Button restartButton;

        [SerializeField] private GameObject returnButtonObj;
        [SerializeField] private GameObject restartButtonObj;

        private void Start()
        {
            returnButtonObj.SetActive(false);
            restartButtonObj.SetActive(false);

            returnButton.onClick.AddListener(Return);
            restartButton.onClick.AddListener(Restart);

            StartCoroutine()
        }
        private void Return()
        {
            SwitchScene.SwitchSceneTo(GlobalKeys.LEVEL_CHOOSING_SCENE_INDEX);
        }
        private void Restart()
        {
            SwitchScene.RestartScene();
        }
    }
}