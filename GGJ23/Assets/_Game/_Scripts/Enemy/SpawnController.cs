using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game.Enemy
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
        public List<Transform> spawnPoints => _spawnPoints;

        private void Awake() 
        {
            var spawnPointsArr = GetComponentsInChildren<Transform>();
            _spawnPoints = spawnPointsArr.OfType<Transform>().ToList();
            _spawnPoints.Remove(this.transform);
        }
    }
}
