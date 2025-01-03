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

        [SerializeField] private List<GameObject> allTowers;
        
        private List<GameObject> _avalibleTowers = new List<GameObject>();

        public int Levels { get; set; }

        private void Awake()
        {
            if (main != null && main != this) Destroy(this);
            else { main = this; DontDestroyOnLoad(main); }

            LoadLevels();
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F2))
            {
                ResetLevels();
            }

            if(Input.GetKeyDown(KeyCode.F1))
            {
                if(Input.GetKeyDown(KeyCode.Alpha2))
                {
                    ResetToCurrentLevel(2);
                }
            }
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if(Input.GetKeyDown(KeyCode.Alpha3))
                {
                    ResetToCurrentLevel(3);
                }
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
                Levels = PlayerPrefs.GetInt(GlobalKeys.LEVELS_PP_STRING);
            }
        }
        public void LoadTowers()
        {
            if(_avalibleTowers != null) _avalibleTowers.Clear();

            switch(Levels)
            {
                case 1:
                    {
                        _avalibleTowers.Add(allTowers[0]);
                        break;
                    }
                case 2:
                    {
                        _avalibleTowers.Add(allTowers[0]);
                        _avalibleTowers.Add(allTowers[1]);
                        break;
                    }
                case 3:
                    {
                        _avalibleTowers.Add(allTowers[0]);
                        _avalibleTowers.Add(allTowers[1]);
                        _avalibleTowers.Add(allTowers[2]);
                        break;
                    }
                case 4:
                    {
                        _avalibleTowers.Add(_avalibleTowers[0]);
                        _avalibleTowers.Add(_avalibleTowers[1]);
                        _avalibleTowers.Add(_avalibleTowers[2]);
                        _avalibleTowers.Add(_avalibleTowers[3]);
                        break;
                    }
                default:
                    {
                        throw new Exception("Error!");
                    }
            }
        }
        public void LevelCompleted()
        {
            if (Levels == 1) { ChangeLevel(2); return; }
            if (Levels == 2) { ChangeLevel(3); return; }
            if (Levels == 3) { ChangeLevel(4); return; }
            if (Levels <= 4) Debug.LogWarning("That's all");
        }
        private void ChangeLevel(int level)
        {
            Levels = level;
            PlayerPrefs.SetInt(GlobalKeys.LEVELS_PP_STRING, Levels);
        }
        public List<GameObject> GetAvalibleTowers()
        {
            return _avalibleTowers;
        }
        public void ResetLevels()
        {
            Levels = 1;
            PlayerPrefs.SetInt(GlobalKeys.LEVELS_PP_STRING, Levels);
            SwitchScene.SwitchSceneTo(GlobalKeys.MAIN_MENU_SCENE_INDEX);
        }
        private void ResetToCurrentLevel(int level)
        {
            Levels = level;
            PlayerPrefs.SetInt(GlobalKeys.LEVELS_PP_STRING, Levels);
            SwitchScene.SwitchSceneTo(GlobalKeys.MAIN_MENU_SCENE_INDEX);
        }
    }
}