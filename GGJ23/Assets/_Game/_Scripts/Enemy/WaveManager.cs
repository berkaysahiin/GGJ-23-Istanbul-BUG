using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Utils;

namespace Game.Enemy
{
    public class WaveManager : SingletonMonoBehaviour<WaveManager>
    {
        [SerializeField] private List<Wave> waves;
        private SpawnController _spawnController;

        private void Awake()
        {
            SetupInstance();
            _spawnController = FindObjectOfType<SpawnController>();
        }

        private void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                var wave = Instantiate(waves[i].gameObject, transform.position, Quaternion.identity);
                wave.transform.SetParent(transform);
                waves.Add(wave.GetComponent<Wave>());
                wave.SetActive(false);
            }
        }

        private void Update()
        {
            for (var i = 0; i < waves.Count; i++)
            {
                var wave = waves[i];
                
                wave.StartWave(i);

                if (wave.IsWaveFinished)
                {
                    wave.gameObject.SetActive(false);
                }
            }
        }
    }
}
