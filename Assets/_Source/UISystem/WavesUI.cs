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

        private void Awake()
        {
            _waveManager = FindAnyObjectByType<WaveManager>();

            OnWavesDraw += UpdateWaveText;
        }
        private void UpdateWaveText()
        {
            waveText.text = $"{_waveManager.GetCurrentWaveID()}/{_waveManager.GetWavesCount()}";
        }
    }
}