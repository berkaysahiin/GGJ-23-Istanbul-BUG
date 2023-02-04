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
            var enemy = FindObjectOfType<EnemyController>();
            if(enemy == null) return;
            
            _navMesh.SetDestination(enemy.transform.position);

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
                GetComponent<Animator>().SetBool("explode", true);
                Destroy(this.gameObject, 0.8f);
            }
        }
    }
}
