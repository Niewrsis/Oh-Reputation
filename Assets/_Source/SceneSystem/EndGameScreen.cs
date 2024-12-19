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

        private void Start()
        {
            screenPreab.SetActive(false);

            OnGameEnd += EndGame;
        }
        private void EndGame()
        {
            screenPreab.SetActive(true);
            EndGameState(LevelManager.Instance.CurrentGameState);
        }
        private void EndGameState(GameState gameState)
        {
            if(gameState == GameState.Win)
            {
                GameManager.main.LevelCompleted();
            }
        }
        private void OnDisable()
        {
            Time.timeScale = 1f;
            OnGameEnd -= EndGame;
        }
    }
}