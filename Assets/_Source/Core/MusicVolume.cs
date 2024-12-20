using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class MusicVolume : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private AudioSource _audioSorce;

        private void Start()
        {
            _audioSorce = FindObjectOfType<GameManager>().GetComponent<AudioSource>();

            slider.value = _audioSorce.volume;
        }

        private void Update()
        {
            _audioSorce.volume = slider.value;
        }
    }
}