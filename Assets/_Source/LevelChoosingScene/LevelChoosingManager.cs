using Core;
using SceneSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelChoosingMenu
{
    public class LevelChoosingManager : MonoBehaviour
    {
        [SerializeField] private Button firstLevel;
        [SerializeField] private Button secondLevel;
        [SerializeField] private Button thirdLevel;
        [SerializeField] private Button fourthLevel;
        [SerializeField] private Button fifthLevel;
        [SerializeField] private Button sixthLevel;
        [SerializeField] private Button seventhLevel;

        private int _levelIndex;

        private void Start()
        {
            _levelIndex = GameManager.main.Levels;

            switch (_levelIndex)
            {
                case 0:
                    Debug.Log("WHY TF YOU ARE ZERO??!!!?!?!!??!?!?!");
                    break;
                case 1:
                    firstLevel.enabled = true;
                    secondLevel.enabled = false;
                    thirdLevel.enabled = false;
                    break;
                case 2:
                    firstLevel.enabled = true;
                    secondLevel.enabled = true;
                    thirdLevel.enabled = false;
                    break;
                case 3:
                    firstLevel.enabled = true;
                    secondLevel.enabled = true;
                    thirdLevel.enabled = true;
                    break;
            }
            firstLevel.onClick.AddListener(GoOnLevel1);
            secondLevel.onClick.AddListener(GoOnLevel2);
            thirdLevel.onClick.AddListener(GoOnLevel3);
        }
        private void GoOnLevel1() { SwitchLevelScene(GlobalKeys.LEVEL_1_SCENE_INDEX); }
        private void GoOnLevel2() { SwitchLevelScene(GlobalKeys.LEVEL_2_SCENE_INDEX); }
        private void GoOnLevel3() { SwitchLevelScene(GlobalKeys.LEVEL_3_SCENE_INDEX); }
        private void SwitchLevelScene(int index) { SwitchScene.SwitchSceneTo(index); }
    }
}