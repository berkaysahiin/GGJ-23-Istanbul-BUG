using System;
using UnityEngine;
using Game.Enemy;

namespace Game.Controllers
{
    public class OxygenController : MonoBehaviour
    {
       private static float _oxygenAmount;

        public static float OxygenAmount
        {
            get => _oxygenAmount;
            set => _oxygenAmount = value;
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

        public static void DecreaseOxygenAmount(float decreaseValue)
        {
            _oxygenAmount -= decreaseValue * Time.deltaTime;
        }
    }
}