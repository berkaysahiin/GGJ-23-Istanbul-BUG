using System.Collections.Generic;
using Game.Managers;
using Game.UIs;
using UnityEngine;
using Game.Utils;

namespace Game.Enemy
{
    public class WaveManager : SingletonMonoBehaviour<WaveManager>
    {
        private SpawnController _spawnController;

        private void Awake()
        {
            SetupInstance();
            _spawnController = FindObjectOfType<SpawnController>();
        }

        public void HandleDay(DayCycleController dayCycleController)
        {
            if(dayCycleController.dayFinished) return;
            SpawnWave(dayCycleController.GetNewReadyWave());
        }

        public void SpawnWave(Wave wave) 
        {
            if(wave is null) return;
        
            print("new way in coming " + wave);

            List<Vector3> spawnPoints = _spawnController.GetRandomPoints(wave.totalEnemyCount);
            foreach(var location in spawnPoints)
            {
                EnemyFactory.Instance.InstantiateEnemy(EnemyType.Oduncu, location);
            }
        }
    }
}
