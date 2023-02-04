using System;
using UnityEngine;

namespace Game
{
    public class Wave 
    {
        private float _duration;
        private int _totalEnemyCount;

        public float duration => _duration;
        public int totalEnemyCount => _totalEnemyCount;
        public float difficultyLevel => _duration;

        public Wave(float duration, int totalEnemyCount)
        {
            _duration = duration;
            _totalEnemyCount = totalEnemyCount;
        }
    }
}
