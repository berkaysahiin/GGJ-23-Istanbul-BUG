using System;
using DG.Tweening;
using Game.Utils;
using UnityEngine;

namespace Game.Managers
{
    public class CameraManager : SingletonMonoBehaviour<CameraManager>
    {
        private Camera _camera;
        
        private void Awake()
        {
            SetupInstance();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        public void ShakeCamera(float duration = 0.8f, float strength = 1, int vibration = 10, float randomness = 20)
        {
            try
            {
                _camera.transform.DOShakePosition(duration, strength, vibration, randomness);  
            }
            catch (Exception e)
            {
                Debug.LogWarning("Warning: " + e.Message);
            }
        }
    }
}
