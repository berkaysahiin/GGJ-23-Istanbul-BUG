using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class DayCycleController : MonoBehaviour
    {
        public bool newWaveReady => !dayFinished && _sinceLastWave > waves.Peek().duration;
        public bool dayFinished => waves.Count == 0;
        public Stack<Wave> waves = new Stack<Wave>();
        public float _sinceLastWave = 1000000;

        public void Update()
        {
            _sinceLastWave += Time.deltaTime;
        }

        public Wave GetNewReadyWave()
        {
            if(!newWaveReady) return null;
            _sinceLastWave = 0;
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
                this.waves.Push(
                    new Wave(7, 3)
                );
            }
        }
    }
}
