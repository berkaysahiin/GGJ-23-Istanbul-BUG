using UnityEngine;
using System;

namespace Game.Enemy
{
    public class LevelManager : MonoBehaviour
    {
        public bool isDay => !_dayCycleController.dayFinished;
        public bool isNight => _dayCycleController.dayFinished;

        public Action OnDay;
        public Action OnNight;


        private WaveManager _waveManager;
        private DayCycleController _dayCycleController;
        private int _dayCount = 1;
        private Light _light;

        public void BUTTON_TEST()
        {
            NewDay();
        }

        private void Awake()
        {
            _waveManager = FindObjectOfType<WaveManager>();
            _dayCycleController = FindObjectOfType<DayCycleController>();
            _light = FindObjectOfType<Light>();
        }

        private void Update() 
        {
            _waveManager.HandleDay(_dayCycleController);
            
                
            if(isDay) 
            {
                _light.intensity = 1;
                OnDay?.Invoke();
            }
            else
            {
                _light.intensity = 0.20f;
                OnNight?.Invoke();
            }
        }

        private void NewDay()
        {
            Destroy(_dayCycleController.gameObject);
            _dayCycleController = DayCycleController.New(_dayCount * 2);
            _dayCount++;
        }
    }
}
