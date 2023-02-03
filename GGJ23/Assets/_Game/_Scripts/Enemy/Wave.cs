using System;
using Game.Enemy;
using UnityEngine;

namespace Game
{
    public class Wave : MonoBehaviour
    {
        private float _duration = 5;
        private int _totalEnemyCount;
        private int _difficultyLevel;

        private float _currentWaveTime;

        public bool IsWaveFinished => _duration >= _currentWaveTime;
    }
}
