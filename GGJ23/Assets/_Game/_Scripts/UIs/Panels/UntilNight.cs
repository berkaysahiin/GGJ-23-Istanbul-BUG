using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Game.Enemy;

namespace Game.UIs
{
    public class UntilNight: MonoBehaviour
    {
        private TextMeshProUGUI text;

        private void Awake()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update() 
        {
            if(LevelManager.Instance.untilNight > 0)
                text.text = "Until Night: " + (int)LevelManager.Instance.untilNight;
            else
                text.text = "Until Day: " + (int)LevelManager.Instance.untilDay;
        }
    }
}
