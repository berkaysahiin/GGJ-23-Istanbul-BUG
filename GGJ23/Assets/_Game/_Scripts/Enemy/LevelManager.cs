using UnityEngine;
using DG.Tweening;

namespace Game.Enemy
{
    public class LevelManager : MonoBehaviour
    {
        private WaveManager waveController;
        Sequence waveSequence;

        private void Awake()
        {
            waveController = FindObjectOfType<WaveManager>();
        }

        private void Start()
        {
        }


        private void Update()
        {

        }
    }
}
