using System;
using UnityEngine;
using Game.Enemy;
using Game.Utils;

namespace Game.Controllers
{
    public class OxygenController : SingletonMonoBehaviour<OxygenController>
    {
       private static float _oxygenAmount;

        public static float OxygenAmount
        {
            get => _oxygenAmount;
            set => _oxygenAmount = value;
        }

        private void Awake()
        {
            SetupInstance();
        }

        private void Start()
        {
            _oxygenAmount += 40;
        }

        public void ResetOxygenAmount()
        {
            _oxygenAmount = 0;
        }

        public static void IncreaseOxygenAmount(float increaseValue)
        {
            if(LevelManager.Instance.isNight) return;
            
            _oxygenAmount += increaseValue * Time.deltaTime;
        }

        public void DecreaseOxygenAmount(float decreaseValue)
        {
            _oxygenAmount -= decreaseValue;
        }
    }
}