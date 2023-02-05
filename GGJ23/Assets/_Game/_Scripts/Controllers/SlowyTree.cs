using Game.Controllers;
using Game.Enemy;
using Game.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class SlowyTree : BaseTreeController
    {
        [SerializeField] private float radius;
        [SerializeField] private float coefficent;

        protected override void Start()
        {
            if (rootVfx == null)
            {
                return;
            }
            
            spawnedVfx = Instantiate(rootVfx, FindObjectOfType<MainTreeController>().transform.position + new Vector3(0, 0, 0), Quaternion.identity);

        }

        protected override void Update()
        {
            base.Update();
            
            spawnedVfx.GetComponentsInChildren<Transform>()[2].transform.position = transform.position;
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            float minDistance = float.MaxValue;

            foreach (var collider in colliders)
            {
                if (collider.gameObject.GetComponent<EnemyController>() != null)
                {
                    collider.gameObject.GetComponent<NavMeshAgent>().speed = 0.7f;
                }
            }
        }
    }
}
