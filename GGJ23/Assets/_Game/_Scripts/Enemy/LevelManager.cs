using UnityEngine;

namespace Game.Enemy
{
    public class LevelManager : MonoBehaviour
    {
        public bool isDay => !_dayCycleController.dayFinished;
        public bool isNight => _dayCycleController.dayFinished;

        private WaveManager _waveManager;
        private DayCycleController _dayCycleController;
        private int _dayCount = 1;
        private float nightLength => 10;
        private float sinceNight;


        private void Awake()
        {
            _waveManager = FindObjectOfType<WaveManager>();
            _dayCycleController = FindObjectOfType<DayCycleController>();
        }

        private void Update() 
        {
            _waveManager.HandleDay(_dayCycleController);

            if(isNight) {
                sinceNight += Time.deltaTime;
                if(sinceNight > nightLength) {
                    NewDay();
                }

            }

            if(isDay) {
                sinceNight = 0;
            }

                
            print(sinceNight);
            Debug.Log("isDay " + isDay);
        }

        public void NewDay()
        {
            Destroy(_dayCycleController.gameObject);
            _dayCycleController = DayCycleController.New(_dayCount * 2);
            _dayCount++;
        }
    }
}
