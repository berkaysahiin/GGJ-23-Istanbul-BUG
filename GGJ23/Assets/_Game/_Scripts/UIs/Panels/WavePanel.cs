using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Game.Enemy;

namespace Game.UIs
{
    public class WavePanel : MonoBehaviour
    {
        private TextMeshProUGUI _waveText;

        private void Awake() 
        {
            _waveText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            SetWaveText();
        }

        private void SetWaveText()
        {
            _waveText.text = "Wave: " + LevelManager.Instance.dayCount.ToString();
        }

    }
}