using System;
using UnityEngine;

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

        public void IncreaseOxygenAmount(float increaseValue)
        {
            _oxygenAmount += increaseValue * Time.deltaTime;
        }

        public void DecreaseOxygenAmount(float decreaseValue)
        {
            _oxygenAmount -= decreaseValue * Time.deltaTime;
        }
    }
}