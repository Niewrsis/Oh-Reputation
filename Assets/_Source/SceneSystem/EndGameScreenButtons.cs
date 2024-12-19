using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SceneSystem
{
    public class EndGameScreenButtons : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [Header("Buttons")]
        [SerializeField] private Button returnButton;
        [SerializeField] private Button restartButton;

        [Header("Objects")]
        [SerializeField] private GameObject returnButtonObj;
        [SerializeField] private GameObject restartButtonObj;

        private void Start()
        {
            returnButtonObj.SetActive(false);
            restartButtonObj.SetActive(false);

            returnButton.onClick.AddListener(Return);
            restartButton.onClick.AddListener(Restart);
        }
        private void OnEnable()
        {
            StartCoroutine(EndAnim());
        }
        private IEnumerator EndAnim()
        {
            Time.timeScale = 1f;
            yield return new WaitForSeconds(1);
            if (LevelManager.Instance.CurrentGameState == GameState.Lose)
            {
                animator.SetTrigger("Lose");
            }
            else
            {
                animator.SetTrigger("Win");
            }
            returnButtonObj.SetActive(true);
            restartButtonObj.SetActive(true);

            
            Time.timeScale = 0f;
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