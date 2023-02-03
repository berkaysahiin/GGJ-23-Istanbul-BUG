using System;
using Game.Controllers;
using TMPro;
using UnityEngine;

namespace Game.UIs
{
    public class OxygenPanel : MonoBehaviour
    {
        private OxygenController _oxygenController;
        private TextMeshProUGUI _oxygenText;

        private void Awake()
        {
            _oxygenText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            SetOxygenText();
        }

        private void SetOxygenText()
        {
            _oxygenText.text = Convert.ToInt32(OxygenController.OxygenAmount).ToString();
        }
    }
}
