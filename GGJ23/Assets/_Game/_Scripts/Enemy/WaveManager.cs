using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using Game.Utils;

namespace Game.Enemy
{
    public class WaveManager : SingletonMonoBehaviour<WaveManager>
    {
        private SpawnController spawnController;
        private int waveCount = 1;

        private void Awake()
        {
            SetupInstance();
            spawnController = FindObjectOfType<SpawnController>();
        }
}
