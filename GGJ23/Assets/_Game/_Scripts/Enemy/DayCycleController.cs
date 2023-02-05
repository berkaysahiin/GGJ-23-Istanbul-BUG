using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class DayCycleController : MonoBehaviour
    {
        public bool newWaveReady => !allWavesSpawned && _sinceLastWave > waves.Peek().duration;
        public bool dayFinished => allWavesSpawned && _sinceLastWave > lastDuration;
        public float untilNight => _untilNight;
        public bool allWavesSpawned => waves.Count == 0;
        public Stack<Wave> waves = new Stack<Wave>();

        private float _sinceLastWave = 1000000;
        private float lastDuration;
        private float _untilNight;

        public void Update()
        {
            _sinceLastWave += Time.deltaTime;
            _untilNight = untilNight > 0 ? untilNight - Time.deltaTime : 0;
        }

        public Wave GetNewReadyWave()
        {
            if(!newWaveReady) return null;
            _sinceLastWave = 0;
            lastDuration = waves.Peek().duration;
            return waves.Pop();
        }

        public static DayCycleController New(int waveCount) 
        {
            var obj = new GameObject("DayCycle");
            var dayCycleController =  obj.AddComponent<DayCycleController>();
            dayCycleController.AddWaves(waveCount);
            return dayCycleController;
        }

        private void AddWaves(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                var duration = 7;
                var enemyCount = 2;
                this.waves.Push(
                    new Wave(duration, enemyCount)
                );
                _untilNight += duration;
            }
        }
    }
}
