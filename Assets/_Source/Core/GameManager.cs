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
            switch (PlayerPrefs.GetInt(GlobalKeys.LEVELS_PP_STRING))
            {
                case 1:
                    {
                        Levels = 2;
                        PlayerPrefs.SetInt(GlobalKeys.LEVELS_PP_STRING, Levels);
                        break;
                    }
                case 2:
                    {
                        Levels = 3;
                        PlayerPrefs.SetInt(GlobalKeys.LEVELS_PP_STRING, Levels);
                        break;
                    }
                case 3:
                    {
                        Levels = 4;
                        PlayerPrefs.SetInt(GlobalKeys.LEVELS_PP_STRING, Levels);
                        break;
                    }
                default:
                    {
                        throw new Exception("Comlete level error!");
                    }
            }
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
    }
}