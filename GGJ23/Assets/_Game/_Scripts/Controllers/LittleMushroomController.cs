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
            var enemy = GetClosestEnemy();
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
            if (other.gameObject.tag.Equals("Enemy"))
            {
                Destroy(other.gameObject);
                GetComponent<Animator>().SetBool("explode", true);
                Destroy(this.gameObject, 0.8f);
            }
        }
        
        private EnemyController GetClosestEnemy()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 40);

            float minDistance = float.MaxValue;
            EnemyController enemy = null;

            foreach(var collider in colliders)
            {
                if(collider.gameObject.GetComponent<EnemyController>() is null) continue;

                var distance = Vector3.Distance(transform.position, collider.gameObject.transform.position);

                if(distance < minDistance)
                {
                    minDistance = distance;
                    enemy = collider.GetComponent<EnemyController>();
                }
            }

            return enemy;
        }
    }
}
