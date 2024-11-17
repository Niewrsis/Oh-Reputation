using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace SceneSystem
{
    public class EndGameScreen : MonoBehaviour
    {
        public static UnityAction OnGameEnd;

        [SerializeField] private GameObject screenPreab;
        [SerializeField] private TextMeshProUGUI gameStateText;
        [SerializeField] private TextMeshProUGUI rewardText;

        private float _totalReward;

        private void Start()
        {
            screenPreab.SetActive(false);

            OnGameEnd += EndGame;
        }
        private void EndGame()
        {
            screenPreab.SetActive(true);
            EndGameState(LevelManager.Instance.CurrentGameState);
            Time.timeScale = 0f;
        }
        private void EndGameState(GameState gameState)
        {
            if(gameState == GameState.Win)
            {
                _totalReward = Mathf.RoundToInt(UnityEngine.Random.Range(LevelManager.Instance.MinLevelReward, LevelManager.Instance.MaxLevelReward));

                gameStateText.text = "Win";
                rewardText.text = $"+{_totalReward.ToString()}";

                //TODO: Make logic for adding money to global wallet
            }
            else if(gameState == GameState.Lose)
            {
                gameStateText.text = "Lose";
                rewardText.text = "+0";
            }
            else
            {
                throw new Exception("Current state InGame");
            }
        }
    }
}