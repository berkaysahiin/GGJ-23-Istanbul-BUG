using Game.Managers;
using Game.UIs;
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
        private float nightLength => 3;
        private float sinceNight;
        private CardRendererUI _cardRenderer;

        [SerializeField] Light light;
        [SerializeField] private GameObject dayLight;
        [SerializeField] private GameObject nightLight;

        private void Awake()
        {
            SetupInstance();

            _waveManager = FindObjectOfType<WaveManager>();
            _dayCycleController = FindObjectOfType<DayCycleController>();
            light = FindObjectOfType<Light>();
            _cardRenderer = FindObjectOfType<CardRendererUI>();
        }

        private void Update()
        {
            Debug.Log("IS NIGHT: " + isNight);
            _waveManager.HandleDay(_dayCycleController);
            
            if(light == null) return;
            if(isNight) {
                sinceNight += Time.deltaTime;
                if(sinceNight > nightLength) {
                    NewDay();
                }

                dayLight.SetActive(false);
                nightLight.SetActive(true);
            }

            if(isDay) {
                dayLight.SetActive(true);
                nightLight.SetActive(false);

                sinceNight = 0;
            }
        }

        public void NewDay()
        {
            for (int i = 0; i < 5; i++)
            {
                _cardRenderer.SetupCardDeck();
                _cardRenderer.SetupCardRotations(CardManager.Instance.Cards.Count - 1);
                _cardRenderer.SetupCardPositions(CardManager.Instance.Cards.Count - 1);
            }
            Destroy(_dayCycleController.gameObject);
            _dayCycleController = DayCycleController.New((_dayCount + 1) * 2);
            _dayCount++;
        }

        public void ResetDayCount()
        {
            _dayCount = 0;
        }
    }
}
