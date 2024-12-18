using Core;
using SceneSystem;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [Header("Objects")]
        [SerializeField] private GameObject settingsObj;

        [Header("Buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button closeSettingsButton;

        private bool _isSettingsActive;
        private void Start()
        {
            settingsObj.SetActive(false);
            _isSettingsActive = false;

            startButton.onClick.AddListener(GoToLevelChooser);
            settingsButton.onClick.AddListener(OnSettings);
            closeSettingsButton.onClick.AddListener(OnSettings);
        }
        private void GoToLevelChooser() { SwitchScene.SwitchSceneTo(GlobalKeys.LEVEL_CHOOSING_SCENE_INDEX); }
        private void OnSettings()
        {
            if (_isSettingsActive)
            {
                settingsObj.SetActive(false);
                _isSettingsActive = false;

                startButton.enabled = true;
                settingsButton.enabled = true;
            }
            else
            {
                settingsObj.SetActive(true);
                _isSettingsActive = true;

                startButton.enabled = false;
                settingsButton.enabled = false;
            }
        }
    }
}