using System;
using DG.Tweening;
using Game.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class LittleMushroomController : MonoBehaviour
    {
        private NavMeshAgent _navMesh;

        private void Awake()
        {
            _navMesh = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _navMesh.SetDestination(FindObjectOfType<EnemyController>().transform.position);

            if (LevelManager.Instance.isNight)
            {
                foreach (var mushroom in FindObjectsOfType<LittleMushroomController>())
                {
                    Destroy(mushroom.gameObject);
                }
            }
        }

        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("TESET");
            if (other.gameObject.tag.Equals("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
