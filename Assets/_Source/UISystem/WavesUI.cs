using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using WaveSystem;

namespace UISystem
{
    public class WavesUI : MonoBehaviour
    {
        public static UnityAction OnWavesDraw;

        [SerializeField] private TextMeshProUGUI waveText;

        private WaveManager _waveManager;

        private void Start()
        {
            _waveManager = FindAnyObjectByType<WaveManager>();

            OnWavesDraw += UpdateWaveText;
        }
        private void UpdateWaveText()
        {
            waveText.text = $"Wave {_waveManager.GetCurrentWaveID()}";
        }
    }
}