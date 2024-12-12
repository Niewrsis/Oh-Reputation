using SceneSystem;
using System;
using System.Collections.Generic;
using TowerSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager main;

        public UnityAction OnCurrencyChanged;

        public CurrencySystem CurrencySystem;
        [SerializeField] private float startCurrency;

        public int Levels { get; set; }

        private void Awake()
        {
            if (main != null && main != this) Destroy(this);
            else { main = this; /*DontDestroyOnLoad(main);*/ }

            CurrencySystem = new(startCurrency);
            LoadLevels();
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F2))
            {
                ResetLevels();
            }
        }
        private void LoadLevels()
        {
            if(PlayerPrefs.GetInt(GlobalKeys.LEVELS_PP_STRING) <= 1)
            {
                Levels = 1;
                PlayerPrefs.SetInt(GlobalKeys.LEVELS_PP_STRING, Levels);
            }
            else
            {
                PlayerPrefs.GetInt(GlobalKeys.LEVELS_PP_STRING, Levels);
            }
        }
        public void LevelCompleted() { Levels++; }
        public void ResetLevels()
        {
            Levels = 1;
            PlayerPrefs.SetInt(GlobalKeys.LEVELS_PP_STRING, Levels);
            SwitchScene.SwitchSceneTo(GlobalKeys.MAIN_MENU_SCENE_INDEX);
        }
    }
}