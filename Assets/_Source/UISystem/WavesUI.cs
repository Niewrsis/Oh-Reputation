using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WaveSystem;

namespace UISystem
{
    public class WavesUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI waveText;

        private WaveManager _waveManager;

        private void Start()
        {
            _waveManager = FindAnyObjectByType<WaveManager>();
        }
        private void Update()
        {
            UpdateWaveText();
        }
        private void UpdateWaveText()
        {
            waveText.text = $"Wave {_waveManager.GetCurrentWaveID()}";
        }
    }
}