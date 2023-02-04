using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game.Enemy
{
    public class SpawnController : MonoBehaviour
    {
        private List<Transform> _spawnPoints = new List<Transform>();
        public List<Transform> spawnPoints => _spawnPoints;
    
        private void Awake() 
        {
            var spawnPointsArr = GetComponentsInChildren<Transform>();
            _spawnPoints = spawnPointsArr.ToList();
            _spawnPoints.Remove(this.transform);
        }

        public List<Vector3> GetRandomPoints(int count)
        {
            List<Vector3> returnVector = new List<Vector3>();

            for (int i = 0; i < count; i++)
            {
                int randomIndex = Random.Range(0, _spawnPoints.Count);
                returnVector.Add(_spawnPoints[randomIndex].transform.position);
            }

            return returnVector;
        }
    }
}
