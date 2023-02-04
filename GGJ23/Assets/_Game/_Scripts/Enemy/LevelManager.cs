using UnityEngine;
using Game.Utils;

namespace Game.Enemy
{
    public class LevelManager : SingletonMonoBehaviour<LevelManager>
    {
        public bool isDay => !_dayCycleController.dayFinished;
        public bool isNight => _dayCycleController.dayFinished;
        public int dayCount => _dayCount;

        private WaveManager _waveManager;
        private DayCycleController _dayCycleController;
        private int _dayCount = 0;
        private float nightLength => 10;
        private float sinceNight;

        [SerializeField] Light light;

        private void Awake()
        {
            SetupInstance();

            _waveManager = FindObjectOfType<WaveManager>();
            _dayCycleController = FindObjectOfType<DayCycleController>();
            light = FindObjectOfType<Light>();
        }

        private void Update() 
        {
            _waveManager.HandleDay(_dayCycleController);

            if(light == null) return;
            if(isNight) {
                sinceNight += Time.deltaTime;
                if(sinceNight > nightLength) {
                    NewDay();
                }
                light.intensity = 0.20f;
            }

            if(isDay) {
                light.intensity = 1;
                sinceNight = 0;
            }

            Debug.Log("isDay " + isDay);
        }

        public void NewDay()
        {
            Destroy(_dayCycleController.gameObject);
            _dayCycleController = DayCycleController.New((_dayCount + 1) * 2);
            _dayCount++;
        }
    }
}
