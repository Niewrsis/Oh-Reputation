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
        [Header("Buttons references")]
        [SerializeField] private Button firstLevel;
        [SerializeField] private Button secondLevel;
        [SerializeField] private Button thirdLevel;
        [SerializeField] private Button fourthLevel;
        [SerializeField] private Button fifthLevel;

        [Header("Images references")]
        [SerializeField] private Image secondLevelImage;
        [SerializeField] private Image thirdLevelImage;
        [SerializeField] private Image fourthLevelImage;
        [SerializeField] private Image fifthLevelImage;

        [Header("Sprites locked")]
        [SerializeField] private Sprite secondLevelLocked;
        [SerializeField] private Sprite thirdLevelLocked;
        [SerializeField] private Sprite fourhLevelLocked;
        [SerializeField] private Sprite fifthLevelLocked;

        [Header("Sprites unlocked")]
        [SerializeField] private Sprite secondLevelUnlocked;
        [SerializeField] private Sprite thirdLevelUnlocked;
        [SerializeField] private Sprite fourhLevelUnlocked;
        [SerializeField] private Sprite fifthLevelUnlocked;

        [Header("Other stuff")]
        [SerializeField] private Button returnToMainMenu;

        private void Start()
        {
            switch (GameManager.main.Levels)
            {
                case 0:
                    Debug.Log("WHY TF YOU ARE ZERO??!!!?!?!!??!?!?!");
                    break;
                case 1:
                    firstLevel.enabled = true;
                    secondLevel.enabled = false;
                    thirdLevel.enabled = false;
                    secondLevelImage.sprite = secondLevelLocked;
                    thirdLevelImage.sprite = thirdLevelLocked;
                    fourthLevelImage.sprite = fourhLevelLocked;
                    fifthLevelImage.sprite = fifthLevelLocked;
                    break;
                case 2:
                    firstLevel.enabled = true;
                    secondLevel.enabled = true;
                    thirdLevel.enabled = false;
                    secondLevelImage.sprite = secondLevelUnlocked;
                    thirdLevelImage.sprite = thirdLevelLocked;
                    fourthLevelImage.sprite = fourhLevelLocked;
                    fifthLevelImage.sprite = fifthLevelLocked;
                    break;
                case 3:
                    firstLevel.enabled = true;
                    secondLevel.enabled = true;
                    thirdLevel.enabled = true;

                    secondLevelImage.sprite = secondLevelUnlocked;
                    thirdLevelImage.sprite = thirdLevelUnlocked;
                    fourthLevelImage.sprite = fourhLevelLocked;
                    fifthLevelImage.sprite = fifthLevelLocked;
                    break;
            }
            firstLevel.onClick.AddListener(GoOnLevel1);
            secondLevel.onClick.AddListener(GoOnLevel2);
            thirdLevel.onClick.AddListener(GoOnLevel3);

            returnToMainMenu.onClick.AddListener(ReturnToMain);
        }
        private void GoOnLevel1() { SwitchLevelScene(GlobalKeys.LEVEL_1_SCENE_INDEX); }
        private void GoOnLevel2() { SwitchLevelScene(GlobalKeys.LEVEL_2_SCENE_INDEX); }
        private void GoOnLevel3() { SwitchLevelScene(GlobalKeys.LEVEL_3_SCENE_INDEX); }
        private void SwitchLevelScene(int index) { SwitchScene.SwitchSceneTo(index); }
        private void ReturnToMain() { SwitchLevelScene(GlobalKeys.MAIN_MENU_SCENE_INDEX); }
    }
}